namespace FilmOnline.Logic.Models
{
    /// <summary>
    /// Film country.
    /// </summary>
    public class FilmCountryDto
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Country identification.
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Film identification.
        /// </summary>
        public int FilmId { get; set; }
    }
}