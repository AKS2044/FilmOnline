namespace FilmOnline.Logic.Models
{
    /// <summary>
    /// Watch later film.
    /// </summary>
    public class UserWatchLaterFilmDto
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User identification.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Film identification.
        /// </summary>
        public int FilmId { get; set; }
    }
}
