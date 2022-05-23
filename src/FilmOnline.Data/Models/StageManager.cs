using System.Collections.Generic;

namespace FilmOnline.Data.Models
{
    /// <summary>
    /// Stage managers.
    /// </summary>
    public class StageManager
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Navigation property for FilmStageManager.
        /// </summary>
        public ICollection<FilmStageManager> FilmStageManagers { get; set; }

        /// <summary>
        /// Stage manager.
        /// </summary>
        public string StageManagers { get; set; }
    }
}