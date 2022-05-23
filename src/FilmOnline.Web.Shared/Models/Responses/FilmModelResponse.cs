using FilmOnline.Data.Models;
using System.Collections.Generic;

namespace FilmOnline.Web.Shared.Models.Responses
{
    public class FilmModelResponse
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
        /// Rating kinopoisk.
        /// </summary>
        public string RatingKinopoisk { get; set; }

        /// <summary>
        /// Rating site.
        /// </summary>
        public float RatingSite { get; set; }

        /// <summary>
        /// Rating Imdb.
        /// </summary>
        public string RatingImdb { get; set; }

        /// <summary>
        /// Release date.
        /// </summary>
        public int ReleaseDate { get; set; }

        /// <summary>
        /// Link for file film.
        /// </summary>
        public string LinkFilmPlayer { get; set; }

        /// <summary>
        /// Link for trailer.
        /// </summary>
        public string LinkFilmtrailer { get; set; }

        /// <summary>
        /// Actor.
        /// </summary>
        public List<string> Country { get; set; }

        /// <summary>
        /// Genre.
        /// </summary>
        public List<string> Genre { get; set; }

        /// <summary>
        /// Stage manager.
        /// </summary>
        public List<string> StageManagers { get; set; }

        /// <summary>
        /// Actors.
        /// </summary>
        public List<Actor> Actors { get; set; }

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
    }
}