using BlogApp.Business.Services.Implements;
using BlogApp.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.Business
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
