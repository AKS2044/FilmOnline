using System.ComponentModel.DataAnnotations;

namespace FilmOnline.Web.Shared.Models.Request
{
    public class CommentCreateRequest
    {
        /// <summary>
        /// Comment.
        /// </summary>
        [Required]
        public string Comments { get; set; }

        [Required]
        /// <summary>
        /// User name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Path photo.
        /// </summary>
        public string PathPhoto { get; set; }

        /// <summary>
        /// User identification.
        /// </summary>
        [Required]
        public string UserId { get; set; }

        /// <summary>
        /// Film identification.
        [Required]
        public int FilmId { get; set; }
    }
}