using FilmOnline.Web.Shared.Models.Responses;
using System.Collections.Generic;

namespace FilmOnline.Web.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<FilmShortModelResponse> FilmShortModelResponses { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}