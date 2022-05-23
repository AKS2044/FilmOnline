namespace FilmOnline.Logic.Models
{
    /// <summary>
    /// Film role.
    /// </summary>
    public class FilmActorDto
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Actor identification.
        /// </summary>
        public int ActorId { get; set; }

        /// <summary>
        /// Film identification.
        /// </summary>
        public int FilmId { get; set; }
    }
}