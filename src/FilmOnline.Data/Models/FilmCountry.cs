namespace FilmOnline.Data.Models
{
    /// <summary>
    /// Film country.
    /// </summary>
    public class FilmCountry
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
        /// Navigation property for State.
        /// </summary>
        public State State { get; set; }

        /// <summary>
        /// Film identification.
        /// </summary>
        public int FilmId { get; set; }

        /// <summary>
        /// Navigation property for Film.
        /// </summary>
        public Film Film { get; set; }
    }
}