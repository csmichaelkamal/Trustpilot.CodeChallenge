using Microsoft.AspNetCore.Builder;
using TrustPilot.CodeChallenge.API.Middlewares;

namespace TrustPilot.CodeChallenge.API.Extensions
{
    /// <summary>
    /// Middleware extensions for readability
    /// </summary>
    public static class MiddlewaresExtesions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<GlobalExceptionHandling>();
            return builder;
        }
    }
}
