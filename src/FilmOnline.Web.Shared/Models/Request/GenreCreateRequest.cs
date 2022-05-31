using System.ComponentModel.DataAnnotations;

namespace FilmOnline.Web.Shared.Models.Request
{
    public class GenreCreateRequest
    {
        /// <summary>
        /// Genre.
        /// </summary>
        [Required]
        public string Genres { get; set; }
    }
}