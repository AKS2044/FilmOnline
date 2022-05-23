using System.Collections.Generic;

namespace FilmOnline.Data.Models
{
    /// <summary>
    /// Genre.
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Navigation property for FilmGenres.
        /// </summary>
        public ICollection<FilmGenre> FilmGenres { get; set; }

        /// <summary>
        /// Genre.
        /// </summary>
        public string Genres { get; set; }
    }
}