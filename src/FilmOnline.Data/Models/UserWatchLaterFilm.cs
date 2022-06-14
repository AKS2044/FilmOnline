﻿namespace FilmOnline.Data.Models
{
    /// <summary>
    /// Watch later film.
    /// </summary>
    public class UserWatchLaterFilm
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User identification.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Navigation property for user.
        /// </summary>
        public User User { get; set; }

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
