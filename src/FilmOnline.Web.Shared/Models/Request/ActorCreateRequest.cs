using System.ComponentModel.DataAnnotations;

namespace FilmOnline.Web.Shared.Models.Request
{
    public class ActorCreateRequest
    {
        /// <summary>
        /// First name.
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Second name.
        /// </summary>
        [Required]
        public string SecondName { get; set; }
    }
}