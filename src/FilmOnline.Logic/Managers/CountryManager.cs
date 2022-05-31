using FilmOnline.Data.Models;
using FilmOnline.Logic.Exceptions;
using FilmOnline.Logic.Interfaces;
using FilmOnline.Logic.Models;
using FilmOnline.Web.Shared.Models.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmOnline.Logic.Managers
{
    /// <inheritdoc cref="ICountryManager"/>
    public class CountryManager : ICountryManager
    {
        private readonly IRepositoryManager<State> _countryRepository;

        public CountryManager(IRepositoryManager<State> countryRepository)
        {
            _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
        }

        public async Task CreateAsync(StateDto stateDto)
        {
            var countries = await _countryRepository
               .GetAll()
               .Select(c => new State
               {
                   Id = c.Id,
                   Country = c.Country
               }).ToListAsync();

            foreach (var item in countries)
            {
                if (stateDto.Country == item.Country)
                {
                    throw new NotFoundException($"'{item.Country}' already in the database.");
                }
            }

            var state = new State()
            {
                Country = stateDto.Country
            };

            await _countryRepository.CreateAsync(state);
            await _countryRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<StateDto>> GetAllAsync()
        {
            var stateDtos = new List<StateDto>();

            var countries = await _countryRepository
                .GetAll()
                .Select(c => new State
                {
                    Id = c.Id,
                    Country = c.Country
                }).ToListAsync();

            foreach (var item in countries)
            {
                stateDtos.Add(new StateDto
                {
                    Id = item.Id,
                    Country = item.Country
                });
            }
            return stateDtos;
        }

        public async Task DeleteAsync(int id)
        {
            var country = await _countryRepository
               .GetAll()
               .SingleOrDefaultAsync(r => r.Id == id);

            if (country is null)
            {
                throw new NotFoundException($"'{nameof(id)}' record not found.", nameof(id));
            }

            _countryRepository.Delete(country);
            await _countryRepository.SaveChangesAsync();
        }

        public Task<FilmModelResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(StateDto stateDto)
        {
            var country = await _countryRepository.GetEntityAsync(c => c.Id == stateDto.Id);

            if (stateDto.Country != country.Country)
            {
                country.Country = stateDto.Country;
            }
            await _countryRepository.SaveChangesAsync();
        }
    }
}