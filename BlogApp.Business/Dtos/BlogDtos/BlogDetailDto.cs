﻿using BlogApp.Business.Dtos.BlogLikeDtos;
using BlogApp.Business.Dtos.CategoryDtos;
using BlogApp.Business.Dtos.CommentDtos;
using BlogApp.Business.Dtos.UserDtos;
using BlogApp.Core.Entities;

namespace BlogApp.Business.Dtos.BlogDtos;

public record BlogDetailDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string CoverImageUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public int ViewerCount { get; set; }
    public AuthorDto AppUser { get; set; }
    public IEnumerable<BlogCategoryDto> BlogCategories { get; set; }
    public IEnumerable<CommentListItemDto> Comments { get; set; }
    public IEnumerable<BlogLikeListItemDto> BlogLikes { get; set; }
}
