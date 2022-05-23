namespace FilmOnline.Web.Shared.Models.Responses
{
    public class FilmShortModelResponse
    {
        public int Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        public string NameFilms { get; set; }

        /// <summary>
        /// Release date.
        /// </summary>
        public int ReleaseDate { get; set; }

        /// <summary>
        /// Path to file.
        /// </summary>
        public string PathPoster { get; set; }
    }
}