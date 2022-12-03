using System.ComponentModel.DataAnnotations;

namespace FilmOnline.Web.Shared.Models.Request
{
    public class RatingCreateRequest
    {
        /// <summary>
        /// Film id.
        /// </summary>
        [Required]
        public int FilmId { get; set; }

        /// <summary>
        /// Rating.
        /// </summary>
        [Required]
        public int Rating { get; set; }

        /// <summary>
        /// UserName.
        /// </summary>
        [Required]
        public string UserName { get; set; }
    }
}