namespace FilmOnline.Logic.Models
{
    /// <summary>
    /// Film CommentFilmUser.
    /// </summary>
    public class CommentFilmUserDto
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

        /// <summary>
        /// Comment identification.
        /// </summary>
        public int CommentId { get; set; }
    }
}