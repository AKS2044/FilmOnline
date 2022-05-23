namespace FilmOnline.Data.Models
{
    /// <summary>
    /// Film stage managers.
    /// </summary>
    public class FilmStageManager
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
        /// Navigation property for StageManager.
        /// </summary>
        public StageManager StageManager { get; set; }

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