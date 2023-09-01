using BlogApp.Business.Dtos.BlogDtos;

namespace BlogApp.Business.Services.Interfaces;

public interface IBlogService
{
    Task CreateAsync(BlogCreateDto dto);
    Task UpdateAsync(int id, BlogUpdateDto dto);
    Task<IEnumerable<BlogListItemDto>> GetAllAsync();
    Task RemoveAsync(int id);
    Task<BlogDetailDto> GetByIdAsync(int id);
}
