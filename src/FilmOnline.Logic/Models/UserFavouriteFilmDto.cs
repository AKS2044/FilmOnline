namespace FilmOnline.Logic.Models
{
    /// <summary>
    /// Favourite film.
    /// </summary>
    public class UserFavouriteFilmDto
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
