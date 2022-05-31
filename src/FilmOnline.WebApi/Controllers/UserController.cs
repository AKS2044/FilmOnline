using FilmOnline.Data.Models;
using FilmOnline.Logic.Interfaces;
using FilmOnline.Web.Shared.Models.Responses;
using FilmOnline.WebApi.Contracts.Requests;
using FilmOnline.WebApi.Contracts.Responses;
using FilmOnline.WebApi.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmOnline.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IJwtService _jwtService;
        private readonly AppSettings _appSettings;

        public UserController(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IJwtService jwtService,
            IOptions<AppSettings> appSettings)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));

            if (appSettings is null)
            {
                throw new ArgumentNullException(nameof(appSettings));
            }
            _appSettings = appSettings.Value;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(UserLoginRequest model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                return BadRequest(new { message = "Неправильный логин и (или) пароль" });
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            var token = _jwtService.GenerateJwtToken(user.Id, _appSettings.Secret);
            var userRoles = await _userManager.GetRolesAsync(user);
            var response = new AuthenticateResponse(user, token, userRoles);

            return Ok(response);
        }

        [HttpPost("registration")]
        public async Task<IActionResult> RegistrationAsync(UserRegistationRequest request)
        {
            var user = new User
            {
                Email = request.Email,
                UserName = request.Email
            };

            if (request.Password == request.PasswordConfirm)
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                await _userManager.AddToRoleAsync(user, "User");

                if (!result.Succeeded)
                {
                    return BadRequest(new ErrorResponse<string>
                    {
                        Message = "Can't registration new user.",
                    });
                }
            }
            else
            {
                return BadRequest(new ErrorResponse<string>
                {
                    Message = "Пароли не совпадают."
                });
            }

            var token = _jwtService.GenerateJwtToken(user.Id, _appSettings.Secret);
            var userRoles = await _userManager.GetRolesAsync(user);
            var response = new AuthenticateResponse(user, token, userRoles);

            return Ok(response);
        }

        [HttpPost("logout")]
        public async Task<OkResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpGet("userProfile")]
        public async Task<IActionResult> ProfileAsync([FromBody] string userName)
        {
            User user = await _userManager.FindByNameAsync(userName);

            if (user is null)
            {
                return NotFound(user);
            }
            ProfileUserResponse model = new()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Favourite = user.Favourite,
                WatchLater = user.WatchLater
            };

            return Ok(model);
        }

        [HttpGet("allUsers")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var userResponses = new List<ProfileUserResponse>();

            foreach (var item in users)
            {
                userResponses.Add(new ProfileUserResponse
                {
                    Id = item.Id,
                    Email = item.Email,
                    UserName = item.UserName
                });
            }

            return Ok(userResponses);
        }

        [HttpGet("getToken")]
        public async Task<IActionResult> GetTokenAsync(UserLoginRequest model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                return BadRequest(new { message = "Неправильный логин и (или) пароль" });
            }
            else
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var token = _jwtService.GenerateJwtToken(user.Id, _appSettings.Secret);
                var userRoles = await _userManager.GetRolesAsync(user);
                var response = new AuthenticateResponse(user, token, userRoles);
                return Ok(response);
            }
           
        }

        [HttpDelete("DeleteUser{id}")]
        public async Task<IActionResult> DeleteUsersAsync(string id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            await _userManager.DeleteAsync(user);
            return Ok();
        }
    }
}