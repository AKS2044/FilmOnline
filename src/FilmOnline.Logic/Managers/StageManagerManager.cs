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
    /// <inheritdoc cref="IStageManagerManager"/>
    public class StageManagerManager : IStageManagerManager
    {
        private readonly IRepositoryManager<StageManager> _stageManagerRepository;

        public StageManagerManager(IRepositoryManager<StageManager> stageManagerRepository)
        {
            _stageManagerRepository = stageManagerRepository ?? throw new ArgumentNullException(nameof(stageManagerRepository));
        }

        public async Task CreateAsync(StageManagerDto stageManagerDto)
        {
            var stageManagers = await _stageManagerRepository
                .GetAll()
                .Select(m => new StageManager
                {
                    Id = m.Id,
                    StageManagers = m.StageManagers
                }).ToListAsync();

            foreach (var item in stageManagers)
            {
                if (stageManagerDto.StageManagers == item.StageManagers)
                {
                    throw new NotFoundException($"'{item.StageManagers}' already in the database.");
                }
            }

            var stageManager = new StageManager()
            {
                StageManagers = stageManagerDto.StageManagers
            };

            await _stageManagerRepository.CreateAsync(stageManager);
            await _stageManagerRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<StageManagerDto>> GetAllAsync()
        {
            var stageManagerDtos = new List<StageManagerDto>();

            var stageManagers = await _stageManagerRepository
                .GetAll()
                .Select(m => new StageManager
                {
                    Id = m.Id,
                    StageManagers = m.StageManagers
                }).ToListAsync();

            foreach (var item in stageManagers)
            {
                stageManagerDtos.Add(new StageManagerDto
                {
                    Id = item.Id,
                    StageManagers = item.StageManagers
                });
            }
            return stageManagerDtos;
        }

        public async Task DeleteAsync(int id)
        {
            var actor = await _stageManagerRepository
               .GetAll()
               .SingleOrDefaultAsync(m => m.Id == id);

            if (actor is null)
            {
                throw new NotFoundException($"'{nameof(id)}' record not found.", nameof(id));
            }

            _stageManagerRepository.Delete(actor);
            await _stageManagerRepository.SaveChangesAsync();
        }

        public Task<FilmModelResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(StageManagerDto stageManagerDto)
        {
            var stageManager = await _stageManagerRepository.GetEntityAsync(c => c.Id == stageManagerDto.Id);

            if (stageManagerDto.StageManagers != stageManager.StageManagers && stageManagerDto.StageManagers is not null)
            {
                stageManager.StageManagers = stageManagerDto.StageManagers;
            }
            await _stageManagerRepository.SaveChangesAsync();
        }
    }
}