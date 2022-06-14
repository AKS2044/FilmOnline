using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FilmOnline.Data.Models
{
    public class User : IdentityUser
    {
        /// <summary>
        /// Navigation property for UserFavouriteFilms.
        /// </summary>
        public ICollection<UserFavouriteFilm> UserFavouriteFilms { get; set; }

        /// <summary>
        /// Navigation property for UserWatchLaterFilms.
        /// </summary>
        public ICollection<UserWatchLaterFilm> UserWatchLaterFilms { get; set; }
    }
}