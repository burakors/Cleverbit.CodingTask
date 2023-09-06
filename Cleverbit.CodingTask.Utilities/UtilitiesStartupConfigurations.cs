using Cleverbit.CodingTask.Utilities.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Cleverbit.CodingTask.Utilities
{
    public static class UtilitiesStartupConfigurations
    {
        public static void UseJwtMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<JwtMiddleware>();
        }
    }
}
