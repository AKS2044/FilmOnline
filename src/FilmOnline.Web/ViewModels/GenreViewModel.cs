using FilmOnline.Web.Shared.Models.Responses;
using System.Collections.Generic;

namespace FilmOnline.Web.ViewModels
{
    public class GenreViewModel
    {
        public IEnumerable<GenreModelResponse> GenreModelResponses { get; set; }
        public string Genre { get; set; }
    }
}
