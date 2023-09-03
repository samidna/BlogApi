using BlogApp.Business.Dtos.BlogDtos;
using BlogApp.Core.Enums;
using System.CodeDom.Compiler;

namespace BlogApp.Business.Services.Interfaces;

public interface IBlogService
{
    Task CreateAsync(BlogCreateDto dto);
    Task UpdateAsync(int id, BlogUpdateDto dto);
    Task<IEnumerable<BlogListItemDto>> GetAllAsync();
    Task RemoveAsync(int id);
    Task<BlogDetailDto> GetByIdAsync(int id);
    Task ReactAsync(int id, Reactions reaction);
    Task RemoveReactAsync(int id);
}
