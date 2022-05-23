using FilmOnline.Logic.Interfaces;
using FilmOnline.Logic.Models;
using FilmOnline.Web.Shared.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FilmOnline.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryManager _countryManager;

        public CountryController(ICountryManager countryManager)
        {
            _countryManager = countryManager ?? throw new ArgumentNullException(nameof(countryManager));
        }

        [HttpPost("addCountry")]
        public async Task<IActionResult> CreateAsync([FromBody] CountryCreateRequest request)
        {
            StateDto stateDto = new()
            {
                Country = request.Country
            };

            if (ModelState.IsValid)
            {
                await _countryManager.CreateAsync(stateDto);
            }

            return Ok();
        }

        [HttpGet("allCountry")]
        public async Task<IActionResult> GetAllActor()
        {
            var countries = await _countryManager.GetAllAsync();

            return Ok(countries);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _countryManager.DeleteAsync(id);
        }
    }
}