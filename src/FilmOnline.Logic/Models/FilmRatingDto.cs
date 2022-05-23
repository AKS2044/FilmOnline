namespace FilmOnline.Logic.Models
{
    /// <summary>
    /// Film rating site.
    /// </summary>
    public class FilmRatingDto
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Rating identification.
        /// </summary>
        public int RatingId { get; set; }

        /// <summary>
        /// Film identification.
        /// </summary>
        public int FilmId { get; set; }
    }
}