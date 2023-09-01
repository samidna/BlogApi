using AutoMapper;
using BlogApp.Business.Dtos.CategoryDtos;
using BlogApp.Business.Exceptions.Common;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Business.Services.Implements;

public class CategoryService : ICategoryService
{
    readonly ICategoryRepository _repo;
    readonly IMapper _mapper;

    public CategoryService(ICategoryRepository repo, IMapper mapper)
    {
        _repo=repo;
        _mapper=mapper;
    }

    public async Task CreateAsync(CategoryCreateDto dto)
    {
        Category category = new()
        {
            Name=dto.Name,
            LogoUrl="123",
            IsDeleted=false
        };
        await _repo.CreateAsync(category);
        await _repo.SaveAsync();
    }
    public async Task RemoveAsync(int id)
    {
        var entity = await _getCategoryAsync(id);
        _repo.Delete(entity);
        await _repo.SaveAsync();
    }

    public async Task UpdateAsync(int id, CategoryUpdateDto dto)
    {
        var entity = await _getCategoryAsync(id);
        _mapper.Map(dto, entity);
        await _repo.SaveAsync();
    }

    public async Task<IEnumerable<CategoryListItemDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<CategoryListItemDto>>(_repo.GetAll());
    }

    public async Task<CategoryDetailDto> GetByIdAsync(int id)
    {
        var entity = await _getCategoryAsync(id);
        return _mapper.Map<CategoryDetailDto>(entity);
    }
    async Task<Category> _getCategoryAsync(int id)
    {
        if (id < 1) throw new NegativeIdException();
        var entity = await _repo.FindByIdAsync(id);
        if (entity == null) throw new NotFoundException<Category>();
        return entity;
    }
}
