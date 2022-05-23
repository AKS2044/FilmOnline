using System.Collections.Generic;

namespace FilmOnline.Data.Models
{
    /// <summary>
    /// Rating.
    /// </summary>
    public class Rating
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Navigation property for FilmRatings.
        /// </summary>
        public ICollection<FilmRating> FilmRatings { get; set; }

        /// <summary>
        /// Rating.
        /// </summary>
        public int Ratings { get; set; }
    }
}