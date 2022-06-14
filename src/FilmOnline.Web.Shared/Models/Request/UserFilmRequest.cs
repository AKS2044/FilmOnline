namespace FilmOnline.Web.Shared.Models.Request
{
    public class UserFilmRequest
    {
        /// <summary>
        /// User id.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Film id.
        /// </summary>
        public int FilmId { get; set; }
    }
}
