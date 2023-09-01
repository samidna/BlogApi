using BlogApp.Business.Exceptions.Common;
using Microsoft.AspNetCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace BlogApp.API.Helpers
{
    public static class CustomExceptionHandler
    {
        public static void UseCustomExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(handlerApp =>
            {
                handlerApp.Run(async context =>
                {
                    var feature = context.Features.Get<IExceptionHandlerPathFeature>();
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                    if (feature?.Error is IBaseException ex)
                    {
                        context.Response.StatusCode = ex.StatusCode;
                        await context.Response.WriteAsJsonAsync(new
                        {
                            Message = ex.ErrorMessage,
                            StatusCode = ex.StatusCode
                        });
                    }
                    if (feature?.Error is ArgumentNullException)
                    {
                        await context.Response.WriteAsJsonAsync(new
                        {
                            Message = feature?.Error.Message,
                            StatusCode = StatusCodes.Status400BadRequest
                        }) ;
                    }
                });
            });
        }
    }
}
