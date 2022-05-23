using System.Collections.Generic;

namespace FilmOnline.Data.Models
{
    /// <summary>
    /// Film actor.
    /// </summary>
    public class Actor
    {
        /// <summary>
        /// Identification
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Navigation property for FilmActors.
        /// </summary>
        public ICollection<FilmActor> FilmActors { get; set; }

        /// <summary>
        /// First name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Second name.
        /// </summary>
        public string SecondName { get; set; }
    }
}