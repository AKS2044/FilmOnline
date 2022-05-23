namespace FilmOnline.Logic.Models
{
    /// <summary>
    /// Film stage managers.
    /// </summary>
    public class FilmStageManagerDto
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// StageManagers identification.
        /// </summary>
        public int StageManagerId { get; set; }

        /// <summary>
        /// Film identification.
        /// </summary>
        public int FilmId { get; set; }
    }
}