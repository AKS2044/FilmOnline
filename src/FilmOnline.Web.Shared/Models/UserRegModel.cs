namespace FilmOnline.Web.Shared.Models
{
    public class UserRegModel
    {
        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Password confirm.
        /// </summary>
        public string PasswordConfirm { get; set; }
    }
}