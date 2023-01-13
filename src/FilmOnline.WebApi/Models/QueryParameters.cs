namespace FilmOnline.WebApi.Models
{
    public class QueryParameters
    {
        /// <summary>
        /// Page site
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Genre parameter 
        /// </summary>
        public int GenreId { get; set; }

        /// <summary>
        /// Country parameter 
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Search query 
        /// </summary>
        public string Search { get; set; }
    }
}
