using System.Collections.Generic;

namespace FilmOnline.Data.Models
{
    /// <summary>
    /// Comment.
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date comment.
        /// </summary>
        public string DateSet { get; set; }

        /// <summary>
        /// Comment.
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// User name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Path photo.
        /// </summary>
        public string PathPhoto { get; set; }

        /// <summary>
        /// Like comment.
        /// </summary>
        public int Like { get; set; }

        /// <summary>
        /// Dislike comment.
        /// </summary>
        public int Dislike { get; set; }

        /// <summary>
        /// Navigation property for CommentFilmUser.
        /// </summary>
        public ICollection<CommentFilmUser> CommentFilmUsers { get; set; }
    }
}