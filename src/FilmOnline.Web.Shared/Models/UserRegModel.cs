namespace FilmOnline.Web.Shared.Models
{
    public class UserRegModel
    {
        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Login.
        /// </summary>
        public string UserName { get; set; }

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