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
    /// <inheritdoc cref="IActorManager"/>
    public class ActorManager : IActorManager
    {
        private readonly IRepositoryManager<Actor> _actorRepository;

        public ActorManager(IRepositoryManager<Actor> actorRepository)
        {
            _actorRepository = actorRepository ?? throw new ArgumentNullException(nameof(actorRepository));
        }

        public async Task CreateAsync(ActorDto actorDto)
        {
            var actors = await _actorRepository
               .GetAll()
               .Select(a => new Actor
               {
                   Id = a.Id,
                   FirstName = a.FirstName,
                   LastName = a.LastName,
                   SecondName = a.SecondName
               }).ToListAsync();
            foreach (var item in actors)
            {
                if (actorDto.FirstName == item.FirstName && actorDto.LastName == item.LastName && actorDto.SecondName == item.SecondName)
                {
                    throw new NotFoundException($"'{item.FirstName} {item.LastName}' already in the database.");
                }
            }

            var actor = new Actor()
            {
                FirstName = actorDto.FirstName,
                LastName = actorDto.LastName,
                SecondName = actorDto.SecondName
            };

            await _actorRepository.CreateAsync(actor);
            await _actorRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ActorDto>> GetAllAsync()
        {
            var actorDtos = new List<ActorDto>();

            var actors = await _actorRepository
                .GetAll()
                .Select(a => new Actor
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    SecondName = a.SecondName
                }).ToListAsync();

            foreach (var item in actors)
            {
                actorDtos.Add(new ActorDto
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    SecondName = item.SecondName
                });
            }
            return actorDtos;
        }

        public async Task DeleteAsync(int id)
        {
            var actor = await _actorRepository
               .GetAll()
               .SingleOrDefaultAsync(r => r.Id == id);

            if (actor is null)
            {
                throw new NotFoundException($"'{nameof(id)}' record not found.", nameof(id));
            }

            _actorRepository.Delete(actor);
            await _actorRepository.SaveChangesAsync();
        }

        public Task<FilmModelResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ActorDto model)
        {
            throw new NotImplementedException();
        }
    }
}