using System.Collections.Generic;

namespace FilmOnline.Web.Shared.Models
{
    /// <summary>
    /// User auth model.
    /// </summary>
    public class UserAuthModel
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// UserName.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Roles.
        /// </summary>
        public IList<string> Roles { get; set; }
    }
}