namespace FilmOnline.Logic.Models
{
    /// <summary>
    /// Film Genre.
    /// </summary>
    public class FilmGenreDto
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
        /// Film identification.
        /// </summary>
        public int FilmId { get; set; }
    }
}