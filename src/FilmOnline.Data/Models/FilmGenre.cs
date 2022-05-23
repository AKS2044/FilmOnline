namespace FilmOnline.Data.Models
{
    /// <summary>
    /// Film Genre.
    /// </summary>
    public class FilmGenre
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Genre identification.
        /// </summary>
        public int GenreId { get; set; }

        /// <summary>
        /// Navigation property for Genre.
        /// </summary>
        public Genre Genre { get; set; }

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