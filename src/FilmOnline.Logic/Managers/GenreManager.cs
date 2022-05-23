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
    /// <inheritdoc cref="IGenreManager"/>
    public class GenreManager : IGenreManager
    {
        private readonly IRepositoryManager<Genre> _genreRepository;

        public GenreManager(IRepositoryManager<Genre> genreRepository)
        {
            _genreRepository = genreRepository ?? throw new ArgumentNullException(nameof(genreRepository));
        }

        public async Task CreateAsync(GenreDto genreDto)
        {
            var genres = await _genreRepository
               .GetAll()
               .Select(g => new Genre
               {
                   Id = g.Id,
                   Genres = g.Genres
               }).ToListAsync();

            foreach (var item in genres)
            {
                if (genreDto.Genres == item.Genres)
                {
                    throw new NotFoundException($"'{item.Genres}' already in the database.");
                }
            }

            var genre = new Genre()
            {
                Genres = genreDto.Genres
            };

            await _genreRepository.CreateAsync(genre);
            await _genreRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<GenreDto>> GetAllAsync()
        {
            var genreDtos = new List<GenreDto>();

            var genres = await _genreRepository
                .GetAll()
                .Select(g => new Genre
                {
                    Id = g.Id,
                    Genres = g.Genres
                }).ToListAsync();

            foreach (var item in genres)
            {
                genreDtos.Add(new GenreDto
                {
                    Id = item.Id,
                    Genres = item.Genres
                });
            }
            return genreDtos;
        }

        public async Task DeleteAsync(int id)
        {
            var actor = await _genreRepository
               .GetAll()
               .SingleOrDefaultAsync(g => g.Id == id);

            if (actor is null)
            {
                throw new NotFoundException($"'{nameof(id)}' record not found.", nameof(id));
            }

            _genreRepository.Delete(actor);
            await _genreRepository.SaveChangesAsync();
        }

        public Task<FilmModelResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(GenreDto model)
        {
            throw new NotImplementedException();
        }
    }
}