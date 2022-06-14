using System.Collections.Generic;

namespace FilmOnline.Data.Models
{
    /// <summary>
    /// Film.
    /// </summary>
    public class Film
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        public string NameFilms { get; set; }

        /// <summary>
        /// Age limit.
        /// </summary>
        public int AgeLimit { get; set; }

        /// <summary>
        /// Release date.
        /// </summary>
        public int ReleaseDate { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Time.
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// Path to file.
        /// </summary>
        public string PathPoster { get; set; }

        /// <summary>
        /// Image name.
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// Identification rating kinopoisk.
        /// </summary>
        public int IdRating { get; set; }

        /// <summary>
        /// Rating site.
        /// </summary>
        public string RatingSite { get; set; }

        /// <summary>
        /// Rating kinopoisk.
        /// </summary>
        public string RatingKinopoisk { get; set; }

        /// <summary>
        /// Rating imdb.
        /// </summary>
        public string RatingImdb { get; set; }

        /// <summary>
        /// Link for file film.
        /// </summary>
        public string LinkFilmPlayer { get; set; }

        /// <summary>
        /// Link for trailer.
        /// </summary>
        public string LinkFilmtrailer { get; set; }

        /// <summary>
        /// Navigation property for FilmStageManager.
        /// </summary>
        public ICollection<FilmStageManager> FilmStageManagers { get; set; }

        /// <summary>
        /// Navigation property for FilmActors.
        /// </summary>
        public ICollection<FilmActor> FilmActors { get; set; }

        /// <summary>
        /// Navigation property for FilmRatings.
        /// </summary>
        public ICollection<FilmRating> FilmRatings { get; set; }

        /// <summary>
        /// Navigation property for FilmCountry.
        /// </summary>
        public ICollection<FilmCountry> FilmCountries { get; set; }

        /// <summary>
        /// Navigation property for FilmGenre.
        /// </summary>
        public ICollection<FilmGenre> FilmGenres { get; set; }

        /// <summary>
        /// Navigation property for UserFavouriteFilms.
        /// </summary>
        public ICollection<UserFavouriteFilm> UserFavouriteFilms { get; set; }

        /// <summary>
        /// Navigation property for UserWatchLaterFilms.
        /// </summary>
        public ICollection<UserWatchLaterFilm> UserWatchLaterFilms { get; set; }
    }
}