using BlogApp.Business.ExternalServices.Implements;
using BlogApp.Business.ExternalServices.Interfaces;
using BlogApp.Business.Services.Implements;
using BlogApp.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BlogApp.Business
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddHttpContextAccessor();
        }
    }
}
