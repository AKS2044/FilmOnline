using FilmOnline.Data.Configurations;
using FilmOnline.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace FilmOnline.Data.Contexts
{
    /// <summary>
    /// Main application context
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        /// <summary>
        /// DbSet for Films.
        /// </summary>
        public DbSet<Film> Films { get; set; }

        /// <summary>
        /// DbSet for FilmCountries.
        /// </summary>
        public DbSet<FilmCountry> FilmCountries { get; set; }

        /// <summary>
        /// DbSet for Countries.
        /// </summary>
        public DbSet<State> States { get; set; }

        /// <summary>
        /// DbSet for FilmGenres.
        /// </summary>
        public DbSet<FilmGenre> FilmGenres { get; set; }

        /// <summary>
        /// DbSet for Genres.
        /// </summary>
        public DbSet<Genre> Genres { get; set; }

        /// <summary>
        /// DbSet for FilmRoles.
        /// </summary>
        public DbSet<FilmActor> FilmActors { get; set; }

        /// <summary>
        /// DbSet for Actors.
        /// </summary>
        public DbSet<Actor> Actors { get; set; }

        /// <summary>
        /// DbSet for FilmStageManagers.
        /// </summary>
        public DbSet<FilmStageManager> FilmStageManagers { get; set; }

        /// <summary>
        /// DbSet for StageManagers.
        /// </summary>
        public DbSet<StageManager> StageManagers { get; set; }

        /// <summary>
        /// DbSet for FilmRatings.
        /// </summary>
        public DbSet<FilmRating> FilmRatings { get; set; }

        /// <summary>
        /// DbSet for StageManagers.
        /// </summary>
        public DbSet<Rating> Ratings { get; set; }

        /// <summary>
        /// DbSet for UserFavouriteFilms.
        /// </summary>
        public DbSet<UserFavouriteFilm> UserFavouriteFilms { get; set; }

        /// <summary>
        /// DbSet for UserWatchLaterFilms.
        /// </summary>
        public DbSet<UserWatchLaterFilm> UserWatchLaterFilms { get; set; }

        /// <summary>
        /// Contructor with params.
        /// </summary>
        /// <param name="options">Database context options.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ApplyConfiguration(new ActorsConfiguration());
            builder.ApplyConfiguration(new CountriesConfiguration());
            builder.ApplyConfiguration(new FilmConfiguration());
            builder.ApplyConfiguration(new FilmCountriesConfiguration());
            builder.ApplyConfiguration(new FilmGenresConfiguration());
            builder.ApplyConfiguration(new FilmRolesConfiguration());
            builder.ApplyConfiguration(new FilmStageManagersConfiguration());
            builder.ApplyConfiguration(new FilmRatingsConfiguration());
            builder.ApplyConfiguration(new RatingsConfiguration());
            builder.ApplyConfiguration(new GenresConfiguration());
            builder.ApplyConfiguration(new StageManagersConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserFavouriteFilmsConfiguration());
            builder.ApplyConfiguration(new UserWatchLaterFilmsConfiguration());

            base.OnModelCreating(builder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FilmOnline;Trusted_Connection=True;");
        //}
    }
}