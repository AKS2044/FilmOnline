using System.ComponentModel.DataAnnotations;

namespace FilmOnline.WebApi.Contracts.Requests
{
    public class UserLoginRequest
    {
        ///// <summary>
        ///// User name.
        ///// </summary>
        //[Required]
        //public string UserName { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Remember me.
        /// </summary>
        [Required]
        public bool RememberMe { get; set; }
    }
}