﻿using System.ComponentModel.DataAnnotations;

namespace FilmOnline.Web.Shared.Models.Request
{
    public class CommentCreateRequest
    {
        /// <summary>
        /// Comment.
        /// </summary>
        /// 
        [Required]
        public string Comments { get; set; }

        /// <summary>
        /// User identification.
        /// </summary>
        [Required]
        public string UserId { get; set; }

        /// <summary>
        /// Film identification.
        [Required]
        public int FilmId { get; set; }
    }
}