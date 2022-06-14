using FilmOnline.Web.Shared.Models.Request;
using FilmOnline.Web.Shared.Models.Responses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FilmOnline.Web.ViewModels
{
    public class ActorViewModel
    {
        public IEnumerable<ActorModelResponse> ActorModelResponses { get; set; }

        /// <summary>
        /// Actor object.
        /// </summary>
        public ActorCreateRequest ActorCreateRequest { get; set; }
    }
}
