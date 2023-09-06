using Cleverbit.CodingTask.Data.Core;
using Cleverbit.CodingTask.Host.Models;
using Cleverbit.CodingTask.Utilities.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cleverbit.CodingTask.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public AuthenticationController(IApplicationDbContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<AuthenticationPostResponse> Post(AuthenticationPostRequest request)
        {
            var user = await _context.Users.Where(x => x.UserName == request.UserName).FirstOrDefaultAsync();
            if (user != null)
            {
                if(user.Password == request.Password)
                {
                    return new AuthenticationPostResponse { AuthToken = user.GenerateToken(_configuration) };
                }
                throw new UnauthorizedAccessException();
            }
            throw new UnauthorizedAccessException();
        }
    }
}
