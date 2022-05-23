using FilmOnline.Data.Models;
using FilmOnline.WebApi.Contracts.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FilmOnline.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserChangeController : ControllerBase
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;

        public UserChangeController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // POST api/<UserChangeController>
        [HttpPost("{CreateRole}")]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (!result.Succeeded)
                {
                    return BadRequest(new ErrorResponse<string>
                    {
                        Message = "Can't registration new user.",
                        Errors = result.Errors.Select(error => error.Description)
                    });
                }
            }
            return Ok();
        }

        //// PUT api/<UserChangeController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserChangeController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        //// GET: api/<UserChangeController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<UserChangeController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
    }
}