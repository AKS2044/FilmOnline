using System.Collections.Generic;

namespace FilmOnline.Data.Models
{
    /// <summary>
    /// Country.
    /// </summary>
    public class State
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Navigation property for FilmCountries.
        /// </summary>
        public ICollection<FilmCountry> FilmCountries { get; set; }

        /// <summary>
        /// Country.
        /// </summary>
        public string Country { get; set; }
    }
}