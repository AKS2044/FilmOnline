using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FilmOnline.Web.Shared.Models.Request
{
    public class FilmCreateRequest
    {
        /// <summary>
        /// Film id.
        /// </summary>
        //[Required]
        public int Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [Required]
        public string NameFilms { get; set; }

        /// <summary>
        /// Age limit.
        /// </summary>
        [Required]
        public int AgeLimit { get; set; }

        /// <summary>
        /// Identification rating kinopoisk.
        /// </summary>
        [Required]
        public int IdRating { get; set; }

        /// <summary>
        /// Rating site.
        /// </summary>
        //[Required]
        public float RatingSite { get; set; }

        /// <summary>
        /// Release date.
        /// </summary>
        [Required]
        public int ReleaseDate { get; set; }

        /// <summary>
        /// Link for file film.
        /// </summary>
        public string LinkFilmPlayer { get; set; }

        /// <summary>
        /// Link for trailer.
        /// </summary>
        [Required]
        public string LinkFilmtrailer { get; set; }

        /// <summary>
        /// Country identification.
        /// </summary>
        [Required]
        public List<int> CountryIds { get; set; }

        /// <summary>
        /// Actor identification.
        /// </summary>
        [Required]
        public List<int> ActorIds { get; set; }

        /// <summary>
        /// Genre identification.
        /// </summary>
        [Required]
        public List<int> GenreIds { get; set; }

        /// <summary>
        /// Stage manager identification.
        /// </summary>
        [Required]
        public List<int> StageManagerIds { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        // [Required]
        public string Description { get; set; }

        /// <summary>
        /// Time.
        /// </summary>
        [Required]
        public int Time { get; set; }

        /// <summary>
        /// Path to file.
        /// </summary>
        [Required]
        public string PathPoster { get; set; }

        /// <summary>
        /// Image name.
        /// </summary>
        [Required]
        public string ImageName { get; set; }
    }
}