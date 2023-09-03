using AutoMapper;
using BlogApp.Business.Dtos.BlogDtos;
using BlogApp.Business.Dtos.CategoryDtos;
using BlogApp.Business.Exceptions.Common;
using BlogApp.Business.Exceptions.UserExceptions;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.Core.Enums;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlogApp.Business.Services.Implements;

public class BlogService : IBlogService
{
    readonly IBlogRepository _blogRepo;
    readonly IHttpContextAccessor _context;
    readonly string userId;
    readonly IMapper _mapper;
    readonly ICategoryRepository _catRepo;
    readonly UserManager<AppUser> _userManager;
    readonly IBlogLikeRepository _blogLikeRepo;

    public BlogService(IBlogRepository blogRepo, IHttpContextAccessor context, IMapper mapper, ICategoryRepository catRepo, UserManager<AppUser> userManager, IBlogLikeRepository blogLikeRepo)
    {
        _blogRepo = blogRepo;
        _context = context;
        userId = _context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        _mapper=mapper;
        _catRepo=catRepo;
        _userManager=userManager;
        _blogLikeRepo=blogLikeRepo;
    }

    public async Task CreateAsync(BlogCreateDto dto)
    {
        if (string.IsNullOrWhiteSpace(userId)) throw new ArgumentNullException();
        if (!await _userManager.Users.AnyAsync(u => u.Id==userId)) throw new UserExistException();
        List<BlogCategory> blogCats = new();
        Blog blog = _mapper.Map<Blog>(dto);
        foreach (var id in dto.CategoryIds)
        {
            var cat = await _catRepo.FindByIdAsync(id);
            if (cat == null) throw new CategoryNotFoundException();
            blogCats.Add(new BlogCategory
            {
                Category = cat,
                Blog = blog
            });
        }
        blog.AppUserId=userId;
        blog.BlogCategories = blogCats;
        await _blogRepo.CreateAsync(blog);
        await _blogRepo.SaveAsync();
    }
    
    public async Task<IEnumerable<BlogListItemDto>> GetAllAsync()
    {
        var dto = new List<BlogListItemDto>();
        var entity = _blogRepo.GetAll("AppUser", "BlogCategories", "BlogCategories.Category", "Comments", "Comments.Children", "Comments.AppUser","BlogLikes");
        List<Category> categories = new();
        foreach (var item in entity)
        {
            categories.Clear();
            foreach (var cat in item.BlogCategories)
            {
                categories.Add(cat.Category);
            }
            var dtoItem = _mapper.Map<BlogListItemDto>(item);
            dtoItem.Categories = _mapper.Map<IEnumerable<CategoryListItemDto>>(categories);
            dtoItem.ReactCount = item.BlogLikes.Count;
            dto.Add(dtoItem);
        }
        return dto;
    }

    public async Task<BlogDetailDto> GetByIdAsync(int id)
    {
        if (id<1) throw new NegativeIdException();
        var entity = await _blogRepo.FindByIdAsync(id,"AppUser", "BlogCategories", "BlogCategories.Category", "Comments", "Comments.Children", "Comments.AppUser","BlogLikes","BlogLikes.AppUser");
        if (entity == null) throw new NotFoundException<Blog>();
        entity.ViewerCount++;
        await _blogRepo.SaveAsync();
        return _mapper.Map<BlogDetailDto>(entity);
    }

    public async Task ReactAsync(int id, Reactions reaction)
    {
        await _checkValidate(id);
        var blog = await _blogRepo.FindByIdAsync(id, "BlogLikes");
        if (!blog.BlogLikes.Any(bl => bl.AppUserId == userId && bl.Id == id))
        {
            blog.BlogLikes.Add(new BlogLike
            {
                BlogId = id,
                AppUserId = userId,
                Reaction = reaction 
            });
        }
        else
        {
            var currentReaction = blog.BlogLikes.FirstOrDefault(bl => bl.AppUserId == userId && bl.Id == id);
            if (currentReaction == null) throw new NotFoundException<BlogLike>();
            currentReaction.Reaction = reaction;
        }
        await _blogRepo.SaveAsync();
    }

    public async Task RemoveAsync(int id)
    {
        await _checkValidate(id);
        var entity = await _blogRepo.FindByIdAsync(id);
        if (entity == null) throw new NotFoundException<Blog>();
        if (entity.AppUserId != userId) throw new UserHasNotAccessException();
        _blogRepo.SoftDelete(entity);
        await _blogRepo.SaveAsync();
    }

    public async Task RemoveReactAsync(int id)
    {
        await _checkValidate(id);
        var entity = await _blogLikeRepo.GetSingleAsync(bl => bl.BlogId == id && bl.AppUserId == userId);
        if (entity == null) throw new NotFoundException<BlogLike>();
        _blogLikeRepo.Delete(entity);
        await _blogLikeRepo.SaveAsync();
    }

    public Task UpdateAsync(int id, BlogUpdateDto dto)
    {
        throw new NotImplementedException();
    }
    async Task _checkValidate(int id)
    {
        if (id<1) throw new NegativeIdException(); 
        if (string.IsNullOrWhiteSpace(userId)) throw new ArgumentNullException();
        if (!await _userManager.Users.AnyAsync(u => u.Id==userId)) throw new UserExistException();
    }
}
