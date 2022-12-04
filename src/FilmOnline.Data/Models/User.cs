using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace FilmOnline.Data.Models
{
    public class User : IdentityUser
    {
        /// <summary>
        /// Path to file.
        /// </summary>
        public string PathPhoto { get; set; }

        /// <summary>
        /// Photo name.
        /// </summary>
        public string PhotoName { get; set; }

        /// <summary>
        /// City.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Date registration.
        /// </summary>
        public string DateReg { get; set; }

        /// <summary>
        /// Navigation property for UserFavouriteFilms.
        /// </summary>
        public ICollection<UserFavouriteFilm> UserFavouriteFilms { get; set; }

        /// <summary>
        /// Navigation property for UserWatchLaterFilms.
        /// </summary>
        public ICollection<UserWatchLaterFilm> UserWatchLaterFilms { get; set; }

        /// <summary>
        /// Navigation property for CommentFilmUser.
        /// </summary>
        public ICollection<CommentFilmUser> CommentFilmUsers { get; set; }
    }
}