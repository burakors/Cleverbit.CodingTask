using Cleverbit.CodingTask.Data.Core;
using Cleverbit.CodingTask.Utilities.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Utilities.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IApplicationDbContext dbContext, IConfiguration configuration)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = token!.ValidateToken(configuration);
            if (userId != null)
            {
                context.Items["User"] = await dbContext.Users.FindAsync(Convert.ToInt32(userId.Value));
            }

            await _next(context);
        }
    }
}
