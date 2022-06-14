using FilmOnline.Web.Shared.Models.Responses;
using System.Collections.Generic;

namespace FilmOnline.Web.ViewModels
{
    public class StageManagerViewModel
    {
        public IEnumerable<StageManagerModelResponse> StageManagerModelResponses { get; set; }
        public string StageManager { get; set; }
    }
}
