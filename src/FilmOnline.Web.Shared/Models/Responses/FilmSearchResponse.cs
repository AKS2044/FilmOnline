using System.ComponentModel.DataAnnotations;

namespace FilmOnline.Web.Shared.Models.Request
{
    public class FilmSearchResponse
    {
        /// <summary>
        /// Search.
        /// </summary>
        [Required]
        public string Search { get; set; }
    }
}