using FilmOnline.Data.Models;
using FilmOnline.Logic.Interfaces;
using FilmOnline.Web.Shared.Models.Responses;
using FilmOnline.WebApi.Contracts.Requests;
using FilmOnline.WebApi.Contracts.Responses;
using FilmOnline.WebApi.Settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
        private readonly IFilmManager _filmManager;

        public UserController(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IJwtService jwtService,
            IOptions<AppSettings> appSettings,
            IFilmManager filmManager)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));
            _filmManager = filmManager ?? throw new ArgumentNullException(nameof(filmManager));

            if (appSettings is null)
            {
                throw new ArgumentNullException(nameof(appSettings));
            }
            _appSettings = appSettings.Value;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(UserLoginRequest model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
            
            if (!result.Succeeded)
            {
                return BadRequest(new { message = "Неправильный логин и (или) пароль"});
            }

            var user = await _userManager.FindByNameAsync(model.UserName);
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
                UserName = request.UserName,
                PathPhoto = request.PathPhoto,
                PhotoName = request.PhotoName
            };

            if (request.Password == request.PasswordConfirm)
            {
                await _userManager.CreateAsync(user, request.Password);
                await _userManager.AddToRoleAsync(user, "User");
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

        [HttpGet("auth")]
        public async Task<IActionResult> Auth()
        {
            
            string token = Request.Headers["Authorization"];

            if (token is not null)
            {
                try
                {
                    var handler = new JwtSecurityTokenHandler();
                    token = token.Replace("Bearer ", "");
                    var jsonToken = handler.ReadToken(token);
                    var tokenS = handler.ReadToken(token) as JwtSecurityToken;
                    var id = tokenS.Claims.First(claim => claim.Type == "id").Value;

                    var user = await _userManager.FindByIdAsync(id);
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var response = new AuthenticateResponse(user, token, userRoles);

                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { message = ex.Message });
                }
            }
            else
            {
                return NotFound(new { message = "Пользователь не найден" });
            }
        }

        [HttpGet("userProfile")]
        public async Task<IActionResult> ProfileAsync([FromBody] string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user is null)
            {
                return NotFound(user);
            }
            int totalWatchLater = await _filmManager.TotalAllWatchLaterFilmAsync(user.Id);
            int totalFavourite = await _filmManager.TotalAllFavouriteFilmAsync(user.Id);
            ProfileUserResponse model = new()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                WatchLater = totalWatchLater,
                Favourite = totalFavourite,
                PathPhoto = user.PathPhoto,
                PhotoName = user.PhotoName
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
                var user = await _userManager.FindByEmailAsync(model.UserName);
                var token = _jwtService.GenerateJwtToken(user.Id, _appSettings.Secret);
                var userRoles = await _userManager.GetRolesAsync(user);
                var response = new AuthenticateResponse(user, token, userRoles);
                return Ok(response);
        }

        [HttpDelete("DeleteUser{id}")]
        public async Task<IActionResult> DeleteUsersAsync(string id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            await _userManager.DeleteAsync(user);
            return Ok();
        }

        [HttpGet("CheckUserEmail")]
        public async Task<Boolean> CheckEmailUsersAsync([FromBody] string email)
        {
            var users = await _userManager.Users.ToListAsync();

            foreach (var item in users)
            {
                if (item.Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        [HttpGet("CheckUserName")]
        public async Task<Boolean> CheckNameUsersAsync([FromBody] string name)
        {
            var users = await _userManager.Users.ToListAsync();

            foreach (var item in users)
            {
                if (item.UserName == name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}