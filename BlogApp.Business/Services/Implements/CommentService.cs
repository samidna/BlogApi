using AutoMapper;
using BlogApp.Business.Dtos.CommentDtos;
using BlogApp.Business.Exceptions.Common;
using BlogApp.Business.Exceptions.UserExceptions;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlogApp.Business.Services.Implements;

public class CommentService : ICommentService
{
    readonly ICommentRepository _commentRepo;
    readonly IBlogRepository _blogRepo;
    readonly IMapper _mapper;
    readonly string userId;
    readonly UserManager<AppUser> _userManager;
    readonly IHttpContextAccessor _httpContext;

    public CommentService(ICommentRepository commentRepo, IBlogRepository blogRepo, IMapper mapper, UserManager<AppUser> userManager, IHttpContextAccessor httpContext)
    {
        _commentRepo=commentRepo;
        _blogRepo=blogRepo;
        _mapper=mapper;
        userId = _httpContext.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        _userManager=userManager;
        _httpContext=httpContext;
    }

    public async Task CreateAsync(int id, CommentCreateDto dto)
    {
        if (string.IsNullOrWhiteSpace(userId)) throw new ArgumentNullException();
        if (!await _userManager.Users.AnyAsync(u => u.Id == userId)) throw new UserExistException();
        if (id < 1) throw new NegativeIdException();
        if (!await _blogRepo.IsExistAsync(c => c.Id == id)) throw new NotFoundException<Blog>();
        var comment = _mapper.Map<Comment>(dto);
        comment.AppUserId = userId;
        comment.BlogId = id;
        await _commentRepo.CreateAsync(comment);
        await _commentRepo.SaveAsync();
    }

    public Task<IEnumerable<CommentListItemDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
