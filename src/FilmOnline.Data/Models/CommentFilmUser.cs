namespace FilmOnline.Data.Models
{
    /// <summary>
    /// Film CommentFilmUser.
    /// </summary>
    public class CommentFilmUser
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
        /// Navigation property for User.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Film identification.
        /// </summary>
        public int FilmId { get; set; }

        /// <summary>
        /// Navigation property for Film.
        /// </summary>
        public Film Film { get; set; }

        /// <summary>
        /// Comment identification.
        /// </summary>
        public int CommentId { get; set; }

        /// <summary>
        /// Navigation property for Comment.
        /// </summary>
        public Comment Comment { get; set; }
    }
}