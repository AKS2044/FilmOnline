using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FilmOnline.Data.Models
{
    public class User : IdentityUser
    {
        /// <summary>
        /// Favourite films.
        /// </summary>
        public int Favourite { get; set; }

        /// <summary>
        /// Watch later.
        /// </summary>
        public int WatchLater { get; set; }

        /// <summary>
        /// Navigation property for UserFilms.
        /// </summary>
        public ICollection<UserFilm> UserFilms { get; set; }
    }
}