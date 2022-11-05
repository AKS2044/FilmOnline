using FilmOnline.Data.Models;
using FilmOnline.Logic.Exceptions;
using FilmOnline.Logic.Interfaces;
using FilmOnline.Logic.Models;
using FilmOnline.Web.Shared.Models;
using FilmOnline.Web.Shared.Models.Request;
using FilmOnline.Web.Shared.Models.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace FilmOnline.Logic.Managers
{
    /// <inheritdoc cref="IFilmManager"/>
    public class FilmManager : IFilmManager
    {
        private readonly IRepositoryManager<Film> _filmRepository;
        private readonly IRepositoryManager<FilmActor> _filmActorRepository;
        private readonly IRepositoryManager<FilmCountry> _filmCountryRepository;
        private readonly IRepositoryManager<FilmGenre> _filmGenreRepository;
        private readonly IRepositoryManager<FilmStageManager> _filmStageManagerRepository;
        private readonly IRepositoryManager<FilmRating> _filmRatingRepository;
        private readonly IRepositoryManager<UserFavouriteFilm> _userFavouriteFilmRepository;
        private readonly IRepositoryManager<UserWatchLaterFilm> _userWatchLaterFilmRepository;
        private readonly IRepositoryManager<Rating> _ratingRepository;
        private readonly IRepositoryManager<State> _countryRepository;
        private readonly IRepositoryManager<Genre> _genreRepository;
        private readonly IRepositoryManager<StageManager> _stageManagerRepository;
        private readonly IRepositoryManager<Actor> _actorRepository;

        public FilmManager(IRepositoryManager<Film> filmRepository,
                           IRepositoryManager<FilmActor> filmActorRepository,
                           IRepositoryManager<FilmCountry> filmCountryRepository,
                           IRepositoryManager<FilmGenre> filmGenreRepository,
                           IRepositoryManager<FilmStageManager> filmStageManagerRepository,
                           IRepositoryManager<FilmRating> filmRatingRepository,
                           IRepositoryManager<Rating> ratingRepository,
                           IRepositoryManager<State> countryRepository,
                           IRepositoryManager<Genre> genreRepository,
                           IRepositoryManager<StageManager> stageManagerRepository,
                           IRepositoryManager<Actor> actorRepository,
                           IRepositoryManager<UserWatchLaterFilm> userWatchLaterFilmRepository,
                           IRepositoryManager<UserFavouriteFilm> userFavouriteFilmRepository)
        {
            _filmRepository = filmRepository ?? throw new ArgumentNullException(nameof(filmRepository));
            _filmActorRepository = filmActorRepository ?? throw new ArgumentNullException(nameof(filmActorRepository));
            _filmCountryRepository = filmCountryRepository ?? throw new ArgumentNullException(nameof(filmCountryRepository));
            _filmGenreRepository = filmGenreRepository ?? throw new ArgumentNullException(nameof(filmGenreRepository));
            _filmStageManagerRepository = filmStageManagerRepository ?? throw new ArgumentNullException(nameof(filmStageManagerRepository));
            _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
            _genreRepository = genreRepository ?? throw new ArgumentNullException(nameof(genreRepository));
            _stageManagerRepository = stageManagerRepository ?? throw new ArgumentNullException(nameof(stageManagerRepository));
            _actorRepository = actorRepository ?? throw new ArgumentNullException(nameof(actorRepository));
            _stageManagerRepository = stageManagerRepository ?? throw new ArgumentNullException(nameof(stageManagerRepository));
            _filmRatingRepository = filmRatingRepository ?? throw new ArgumentNullException(nameof(filmRatingRepository));
            _userWatchLaterFilmRepository = userWatchLaterFilmRepository ?? throw new ArgumentNullException(nameof(userWatchLaterFilmRepository));
            _userFavouriteFilmRepository = userFavouriteFilmRepository ?? throw new ArgumentNullException(nameof(userFavouriteFilmRepository));
            _ratingRepository = ratingRepository ?? throw new ArgumentNullException(nameof(ratingRepository));
        }

        public async Task CreateAsync(FilmDto filmDto,
            List<FilmActorDto> filmActorDto,
            List<FilmGenreDto> filmGenreDto,
            List<FilmCountryDto> filmCountryDto,
            List<FilmStageManagerDto> filmStageManagerDto)
        {   
            var film = new Film()
            {
                NameFilms = filmDto.NameFilms,
                AgeLimit = filmDto.AgeLimit,
                ReleaseDate = filmDto.ReleaseDate,
                Description = filmDto.Description,
                Time = filmDto.Time,
                PathPoster = filmDto.PathPoster,
                ImageName = filmDto.ImageName,
                IdRating = filmDto.IdRating,
                RatingSite = 0,
                RatingKinopoisk = filmDto.RatingKinopoisk,
                RatingImdb = filmDto.RatingImdb,
                LinkFilmtrailer = filmDto.LinkFilmtrailer,
                LinkFilmPlayer = filmDto.LinkFilmPlayer
            };
            if (filmDto.RatingImdb is null)
            {
                film.RatingImdb = "0";
            }

            await _filmRepository.CreateAsync(film);
            await _filmRepository.SaveChangesAsync();

            foreach (var item in filmActorDto)
            {
                FilmActor filmActor = new()
                {
                    FilmId = film.Id,
                    ActorId = item.ActorId
                };
                await _filmActorRepository.CreateAsync(filmActor);
            }

            foreach (var item in filmGenreDto)
            {
                FilmGenre filmGenre = new()
                {
                    FilmId = film.Id,
                    GenreId = item.GenreId
                };
                await _filmGenreRepository.CreateAsync(filmGenre);
            }

            foreach (var item in filmCountryDto)
            {
                FilmCountry filmCountry = new()
                {
                    FilmId = film.Id,
                    CountryId = item.CountryId
                };
                await _filmCountryRepository.CreateAsync(filmCountry);
            }

            foreach (var item in filmStageManagerDto)
            {
                FilmStageManager filmStageManager = new()
                {
                    FilmId = film.Id,
                    StageManagerId = item.StageManagerId
                };
                await _filmStageManagerRepository.CreateAsync(filmStageManager);
            }
            await _filmRepository.SaveChangesAsync();
        }

        public async Task UpgradeFilmAsync(FilmDto filmDto,
           List<FilmActorDto> filmActorDto,
           List<FilmGenreDto> filmGenreDto,
           List<FilmCountryDto> filmCountryDto,
           List<FilmStageManagerDto> filmStageManagerDto)
        {
            var film = await _filmRepository.GetEntityAsync(f => f.Id == filmDto.Id);

            if (filmDto.NameFilms != film.NameFilms && filmDto.NameFilms is not null)
            {
                film.NameFilms = filmDto.NameFilms;
            }

            if (filmDto.AgeLimit != film.AgeLimit && filmDto.AgeLimit != 0)
            {
                film.AgeLimit = filmDto.AgeLimit;
            }

            if (filmDto.ReleaseDate != film.ReleaseDate && filmDto.ReleaseDate != 0)
            {
                film.ReleaseDate = filmDto.ReleaseDate;
            }

            if (filmDto.Description != film.Description && filmDto.Description is not null)
            {
                film.Description = filmDto.Description;
            }

            if (filmDto.Time != film.Time && filmDto.Time != 0)
            {
                film.Time = filmDto.Time;
            }

            if (filmDto.RatingSite != film.RatingSite && filmDto.RatingSite != 0)
            {
                film.RatingSite = filmDto.RatingSite;
            }

            if (filmDto.RatingKinopoisk != film.RatingKinopoisk && filmDto.RatingKinopoisk is not null)
            {
                film.RatingKinopoisk = filmDto.RatingKinopoisk;
            }

            if (filmDto.RatingImdb != film.RatingImdb && filmDto.RatingImdb is not null)
            {
                film.RatingImdb = filmDto.RatingImdb;
            }

            if (filmDto.LinkFilmPlayer != film.LinkFilmPlayer && filmDto.LinkFilmPlayer is not null)
            {
                film.LinkFilmPlayer = filmDto.LinkFilmPlayer;
            }

            if (filmDto.LinkFilmtrailer != film.LinkFilmtrailer && filmDto.LinkFilmtrailer is not null)
            {
                film.LinkFilmtrailer = filmDto.LinkFilmtrailer;
            }

            if (filmDto.ImageName != film.ImageName && filmDto.ImageName is not null)
            {
                film.ImageName = filmDto.ImageName;
            }

            if (filmDto.PathPoster != film.PathPoster && filmDto.PathPoster is not null)
            {
                film.PathPoster = filmDto.PathPoster;
            }

            if (filmDto.IdRating != film.IdRating && filmDto.IdRating != 0)
            {
                film.IdRating = filmDto.IdRating;
            }

            if (filmCountryDto.Count != 0)
            {
                var deleteCountry = await _filmCountryRepository.GetAll().Where(d => d.FilmId == film.Id).ToListAsync();
                _filmCountryRepository.DeleteRange(deleteCountry);
                foreach (var item in filmCountryDto)
                {
                    FilmCountry filmCountry = new()
                    {
                        FilmId = film.Id,
                        CountryId = item.CountryId
                    };
                    await _filmCountryRepository.CreateAsync(filmCountry);
                }
            }

            if (filmGenreDto.Count != 0)
            {
                var deleteGenre = await _filmGenreRepository.GetAll().Where(d => d.FilmId == film.Id).ToListAsync();
                _filmGenreRepository.DeleteRange(deleteGenre);
                foreach (var item in filmGenreDto)
                {
                    FilmGenre filmGenre = new()
                    {
                        FilmId = film.Id,
                        GenreId = item.GenreId
                    };
                    await _filmGenreRepository.CreateAsync(filmGenre);
                }
            }

            if (filmStageManagerDto.Count != 0)
            {
                var deleteManager = await _filmStageManagerRepository.GetAll().Where(d => d.FilmId == film.Id).ToListAsync();
                _filmStageManagerRepository.DeleteRange(deleteManager);
                foreach (var item in filmStageManagerDto)
                {
                    FilmStageManager filmStageManager = new()
                    {
                        FilmId = film.Id,
                        StageManagerId = item.StageManagerId
                    };
                    await _filmStageManagerRepository.CreateAsync(filmStageManager);
                }
            }

            if (filmActorDto.Count != 0)
            {
                var deleteActor = await _filmActorRepository.GetAll().Where(d => d.FilmId == film.Id).ToListAsync();
                _filmActorRepository.DeleteRange(deleteActor);
                foreach (var item in filmActorDto)
                {
                    FilmActor filmActor = new()
                    {
                        FilmId = film.Id,
                        ActorId = item.ActorId
                    };
                    await _filmActorRepository.CreateAsync(filmActor);
                }
            }
            

            await _filmRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var filmDelete = await _filmRepository.GetEntityAsync(p => p.Id == id);

            if (filmDelete is null)
            {
                throw new NotFoundException($"'{nameof(id)}' film not found.", nameof(id));
            }

            var actorsDelete = await _filmActorRepository.GetAll().Where(a => a.FilmId == id).ToListAsync();
            var countriesDelete = await _filmCountryRepository.GetAll().Where(a => a.FilmId == id).ToListAsync();
            var genresDelete = await _filmGenreRepository.GetAll().Where(a => a.FilmId == id).ToListAsync();
            var stageManagersDelete = await _filmStageManagerRepository.GetAll().Where(a => a.FilmId == id).ToListAsync();
            var ratingsDelete = await _filmRatingRepository.GetAll().Where(a => a.FilmId == id).ToListAsync();

            _filmRatingRepository.DeleteRange(ratingsDelete);
            _filmStageManagerRepository.DeleteRange(stageManagersDelete);
            _filmGenreRepository.DeleteRange(genresDelete);
            _filmCountryRepository.DeleteRange(countriesDelete);
            _filmActorRepository.DeleteRange(actorsDelete);
            _filmRepository.Delete(filmDelete);
            await _filmRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<FilmDto>> GetAllAsync(int page)
        {
            var FilmDtos = new List<FilmDto>();

            var films = await _filmRepository
                .GetAll().ToListAsync();

            foreach (var item in films)
            {
                var rating = await GetTotalScoreFilm(item.Id);
                FilmDtos.Add(new FilmDto
                {
                    Id = item.Id,
                    NameFilms = item.NameFilms,
                    ReleaseDate = item.ReleaseDate,
                    PathPoster = item.PathPoster,
                    RatingSite = rating
                });
            }

            int pageSize = 2;
            var items = FilmDtos.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return items;
        }

        public async Task<IEnumerable<FilmDto>> GetFilmByGenreAsync(int idGenre)
        {
            var filmGenreIds = await _filmGenreRepository.GetAll().Where(f => f.GenreId == idGenre).Select(f => f.FilmId).ToListAsync();

            var filmGenreLists = new List<FilmDto>();

            foreach (var item in filmGenreIds)
            {
                var resultFilm = await _filmRepository.GetAll().Where(f => f.Id == item).ToListAsync();
                foreach (var film in resultFilm)
                {
                    filmGenreLists.Add(new FilmDto
                    {
                        Id = film.Id,
                        NameFilms = film.NameFilms,
                        ReleaseDate = film.ReleaseDate,
                        PathPoster = film.PathPoster
                    });
                }
            }

            return filmGenreLists;
        }

        public async Task<FilmModelResponse> GetByIdAsync(int id)
        {
            Film film = await _filmRepository.GetEntityAsync(f => f.Id == id);
            var filmCountryIds = await _filmCountryRepository.GetAll().Where(f => f.FilmId == film.Id).Select(f => f.CountryId).ToListAsync();
            var countries = await _countryRepository.GetAll().Where(c => filmCountryIds.Contains(c.Id)).Select(c => c.Country).ToListAsync();

            var filmGenreIds = await _filmGenreRepository.GetAll().Where(f => f.FilmId == film.Id).Select(f => f.GenreId).ToListAsync();
            var genres = await _genreRepository.GetAll().Where(g => filmGenreIds.Contains(g.Id)).Select(g => g.Genres).ToListAsync();

            var filmStageManagerIds = await _filmStageManagerRepository.GetAll().Where(f => f.FilmId == film.Id).Select(f => f.StageManagerId).ToListAsync();
            var stageManagers = await _stageManagerRepository.GetAll().Where(m => filmStageManagerIds.Contains(m.Id)).Select(m => m.StageManagers).ToListAsync();

            var filmActorIds = await _filmActorRepository.GetAll().Where(f => f.FilmId == film.Id).Select(f => f.ActorId).ToListAsync();
            var actors = await _actorRepository.GetAll().Where(a => filmActorIds.Contains(a.Id)).Select(a => new Actor
            {
                FirstName = a.FirstName,
                LastName = a.LastName,
            }).ToListAsync();

            var rating = await GetTotalScoreFilm(film.Id);

            FilmModelResponse model = new()
            {
                Id = film.Id,
                NameFilms = film.NameFilms,
                ImageName = film.ImageName,
                PathPoster = film.PathPoster,
                ReleaseDate = film.ReleaseDate,
                RatingKinopoisk = film.RatingKinopoisk,
                LinkFilmtrailer = film.LinkFilmtrailer,
                LinkFilmPlayer = film.LinkFilmPlayer,
                RatingImdb = film.RatingImdb,
                RatingSite = rating,
                AgeLimit = film.AgeLimit,
                Time = film.Time,
                Description = film.Description,
                Country = countries,
                Genre = genres,
                StageManagers = stageManagers,
                Actors = actors
            };

            return model;
        }

        public async Task<FilmUpgradeModel> GetByIdForUpgradeAsync(int id)
        {
            Film film = await _filmRepository.GetEntityAsync(f => f.Id == id);
            var filmCountryIds = await _filmCountryRepository.GetAll().Where(f => f.FilmId == film.Id).Select(f => f.CountryId).ToListAsync();
            var countries = await _countryRepository.GetAll().Where(c => filmCountryIds.Contains(c.Id)).Select(c => c.Country).ToListAsync();

            var filmGenreIds = await _filmGenreRepository.GetAll().Where(f => f.FilmId == film.Id).Select(f => f.GenreId).ToListAsync();
            var genres = await _genreRepository.GetAll().Where(g => filmGenreIds.Contains(g.Id)).Select(g => g.Genres).ToListAsync();

            var filmStageManagerIds = await _filmStageManagerRepository.GetAll().Where(f => f.FilmId == film.Id).Select(f => f.StageManagerId).ToListAsync();
            var stageManagers = await _stageManagerRepository.GetAll().Where(m => filmStageManagerIds.Contains(m.Id)).Select(m => m.StageManagers).ToListAsync();

            var filmActorIds = await _filmActorRepository.GetAll().Where(f => f.FilmId == film.Id).Select(f => f.ActorId).ToListAsync();
            var actors = await _actorRepository.GetAll().Where(a => filmActorIds.Contains(a.Id)).Select(a => new Actor
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
            }).ToListAsync();

            FilmUpgradeModel model = new()
            {
                Id = film.Id,
                NameFilms = film.NameFilms,
                ImageName = film.ImageName,
                PathPoster = film.PathPoster,
                ReleaseDate = film.ReleaseDate,
                LinkFilmtrailer = film.LinkFilmtrailer,
                AgeLimit = film.AgeLimit,
                IdRating = film.IdRating,
                Time = film.Time,
                Description = film.Description,
                ActorIds = filmActorIds,
                GenreIds = filmGenreIds,
                CountryIds = filmCountryIds,
                StageManagerIds = filmStageManagerIds
            };

            return model;
        }

        public async Task<FilmShortModelResponse> GetByNameAsync(string nameSearch)
        {
            Film film = await _filmRepository.GetAll().FirstOrDefaultAsync(f => f.NameFilms == nameSearch);

            if (film is null)
            {
                throw new NotFoundException($"'{nameof(film.NameFilms)}' film not found.", nameof(film.NameFilms));
            }

            FilmShortModelResponse model = new()
            {
                Id = film.Id,
                NameFilms = film.NameFilms,
                PathPoster = film.PathPoster,
                ReleaseDate = film.ReleaseDate,
            };

            return model;
        }

        public async Task UpdateAsync(FilmDto model)
        {
            model = model ?? throw new ArgumentNullException(nameof(model));

            var filmUpdate = await _filmRepository.GetEntityAsync(p => p.Id == model.Id);

            if (filmUpdate is null)
            {
                throw new NotFoundException($"'{nameof(model.Id)}' project not found.", nameof(model.Id));
            }

            if (filmUpdate.NameFilms != model.NameFilms)
            {
                filmUpdate.NameFilms = model.NameFilms;
            }
        }

        public async Task<int> GetRandomFilmAsync()
        {
            var film = await _filmRepository.GetAll().ToListAsync();
            Random random = new();
            var getCountRandom = random.Next(0, film.Count);
            var randomFilm = film.ElementAtOrDefault(getCountRandom);
            return randomFilm.Id;
        }

        public async Task AddScoreFilmAsync(int idFilm, int score)
        {
            Rating rating = new()
            {
                Ratings = score
            };

            await _ratingRepository.CreateAsync(rating);
            await _ratingRepository.SaveChangesAsync();

            FilmRating filmRating = new()
            {
                FilmId = idFilm,
                RatingId = rating.Id
            };
            await _filmRatingRepository.CreateAsync(filmRating);
            await _filmRatingRepository.SaveChangesAsync();
        }

        public async Task<float> GetTotalScoreFilm(int idFilm)
        {
            var filmRatingIds = await _filmRatingRepository.GetAll().Where(r => r.FilmId == idFilm).Select(r => r.RatingId).ToListAsync();
            var ratings = await _ratingRepository.GetAll().Where(c => filmRatingIds.Contains(c.Id)).Select(c => c.Ratings).ToListAsync();
            float totalNull = 0f;
            if (ratings.Count == 0)
            {
                return totalNull;
            }
            float total = (float)ratings.Sum() / (float)ratings.Count;

            return total;
        }

        public async Task AddFavouriteFilmAsync(int idFilm, string idUser)
        {
            UserFavouriteFilm model = new()
            {
                UserId = idUser,
                FilmId = idFilm
            };
            var isAlready = await _userFavouriteFilmRepository.GetEntityAsync(m => m.UserId == idUser && m.FilmId == idFilm);
            if (isAlready is null)
            {
                await _userFavouriteFilmRepository.CreateAsync(model);
                await _userFavouriteFilmRepository.SaveChangesAsync();
            }
        }

        public async Task DeleteFavouriteFilmAsync(int idFilm, string idUser)
        {
            var model = await _userFavouriteFilmRepository.GetEntityAsync(m => m.UserId == idUser && m.FilmId == idFilm);
            _userFavouriteFilmRepository.Delete(model);
            await _userFavouriteFilmRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<FilmDto>> GetAllFavouriteFilmAsync(string idUser)
        {
            var favouriteFilmIds = await _userFavouriteFilmRepository.GetAll().Where(r => r.UserId == idUser).Select(r => r.FilmId).ToListAsync();
            var films = await _filmRepository.GetAll().Where(r => favouriteFilmIds.Contains(r.Id)).Select(r => new FilmDto
            {
                Id = r.Id,
                NameFilms = r.NameFilms,
                PathPoster = r.PathPoster,
                ReleaseDate = r.ReleaseDate,
                ImageName = r.ImageName
            }).ToListAsync();
            return films;
        }

        public async Task AddWatchLaterFilmAsync(int idFilm, string idUser)
        {
            UserWatchLaterFilm model = new()
            {
                UserId = idUser,
                FilmId = idFilm
            };
            var isAlready = await _userWatchLaterFilmRepository.GetEntityAsync(m => m.UserId == idUser && m.FilmId == idFilm);
            if (isAlready is null)
            {
                await _userWatchLaterFilmRepository.CreateAsync(model);
                await _userWatchLaterFilmRepository.SaveChangesAsync();
            }
        }

        public async Task DeleteWatchLaterFilmAsync(int idFilm, string idUser)
        {
            var model = await _userWatchLaterFilmRepository.GetEntityAsync(m => m.UserId == idUser && m.FilmId == idFilm);
            _userWatchLaterFilmRepository.Delete(model);
            await _userWatchLaterFilmRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<FilmDto>> GetAllWatchLaterFilmAsync(string idUser)
        {
            var wathLaterFilmIds = await _userWatchLaterFilmRepository.GetAll().Where(r => r.UserId == idUser).Select(r => r.FilmId).ToListAsync();
            var films = await _filmRepository.GetAll().Where(r => wathLaterFilmIds.Contains(r.Id)).Select(r => new FilmDto
            {
                Id = r.Id,
                NameFilms = r.NameFilms,
                PathPoster = r.PathPoster,
                ReleaseDate = r.ReleaseDate,
                ImageName = r.ImageName
            }).ToListAsync();
            return films;
        }

        public async Task<int> TotalAllWatchLaterFilmAsync(string idUser)
        {
            var wathLaterFilmIds = await _userWatchLaterFilmRepository.GetAll().Where(r => r.UserId == idUser).Select(r => r.FilmId).ToListAsync();
            return wathLaterFilmIds.Count();
        }

        public async Task<int> TotalAllFavouriteFilmAsync(string idUser)
        {
            var favouriteFilmIds = await _userFavouriteFilmRepository.GetAll().Where(r => r.UserId == idUser).Select(r => r.FilmId).ToListAsync();
            return favouriteFilmIds.Count();
        }
    }
}