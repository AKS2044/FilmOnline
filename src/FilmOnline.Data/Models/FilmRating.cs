namespace FilmOnline.Data.Models
{
    /// <summary>
    /// Film rating site.
    /// </summary>
    public class FilmRating
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
        /// Navigation property for Rating.
        /// </summary>
        public Rating Rating { get; set; }

        /// <summary>
        /// Film identification.
        /// </summary>
        public int FilmId { get; set; }

        /// <summary>
        /// Navigation property for Film.
        /// </summary>
        public Film Film { get; set; }
    }
}