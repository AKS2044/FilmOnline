using FilmOnline.Web.Shared.Models.Responses;
using System.Collections.Generic;

namespace FilmOnline.Web.ViewModels
{
    public class CountryViewModel
    {
        public IEnumerable<CountryModelResponse> CountryModelResponses { get; set; }
        public string Country { get; set; }
    }
}