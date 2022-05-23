using FilmOnline.Data.Models;
using System.Collections.Generic;

namespace FilmOnline.Web.Shared.Models
{
    public class FilmUpgradeModel
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string NameFilms { get; set; }

        /// <summary>
        /// Age limit.
        /// </summary>
        public int AgeLimit { get; set; }

        /// <summary>
        /// Identification rating kinopoisk.
        /// </summary>
        public int IdRating { get; set; }

        ///// <summary>
        ///// Rating site.
        ///// </summary>
        //public float RatingSite { get; set; }

        /// <summary>
        /// Release date.
        /// </summary>
        public int ReleaseDate { get; set; }

        ///// <summary>
        ///// Link for file film.
        ///// </summary>
        //public string LinkFilmPlayer { get; set; }

        /// <summary>
        /// Link for trailer.
        /// </summary>
        public string LinkFilmtrailer { get; set; }

        /// <summary>
        /// Country identification.
        /// </summary>
        public List<string> CountryIds { get; set; }

        /// <summary>
        /// Actor identification.
        /// </summary>
        public List<Actor> ActorIds { get; set; }

        /// <summary>
        /// Genre identification.
        /// </summary>
        public List<string> GenreIds { get; set; }

        /// <summary>
        /// Stage manager identification.
        /// </summary>
        public List<string> StageManagerIds { get; set; }

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