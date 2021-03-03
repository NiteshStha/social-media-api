using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using SocialMediaServer.Helpers;
using SocialMediaServer.Models.Users;
using Utilities.Responses;

namespace SocialMediaServer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly AppSettings _appSettings;

        public UsersController(IRepositoryWrapper repository, IOptions<AppSettings> appSettings)
        {
            _repository = repository;
            _appSettings = appSettings.Value;
        }

        [HttpGet("{id:int}", Name = "GetUser")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var user = await _repository.User.FindById(id);
                // var username = User.Identity.Name;
                // var accessToken = Request.Headers[HeaderNames.Authorization];
                // var jwtEncodedString = accessToken.ToString().Substring(7); // trim 'Bearer ' from the start since its just a prefix for the token string
                // var token = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);
                return Ok(new JsonResponse<User>(StatusCodes.Status200OK, user));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        
        [AllowAnonymous]
        [HttpPost("authenticate", Name = "AuthenticateUser")]
        public async Task<IActionResult> Authenticate([FromBody] SignInModel model)
        {
            try
            {
                var user = await _repository.User.Authenticate(model.Username, model.Password);
                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });
                
                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                
                // return basic user info and authentication token
                return Ok(new
                {
                    Id = user.UserId,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Token = tokenString
                });
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}