using Microsoft.AspNetCore.Builder;

namespace Desafio.API.Infra.Exceptions
{
    public static class ExceptionHandlerExtensions
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionHandler>();
        }
    }
}
