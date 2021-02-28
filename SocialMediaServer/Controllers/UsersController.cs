using System;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SocialMediaServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public UsersController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet("{id:int}", Name = "GetUser")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _repository.User.FindById(id));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}