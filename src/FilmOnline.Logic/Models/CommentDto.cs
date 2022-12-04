﻿using System.Collections.Generic;

namespace FilmOnline.Logic.Models
{
    /// <summary>
    /// Comment.
    /// </summary>
    public class CommentDto
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date comment.
        /// </summary>
        public string DateSet { get; set; }

        /// <summary>
        /// Comment.
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Like comment.
        /// </summary>
        public int Like { get; set; }

        /// <summary>
        /// Dislike comment.
        /// </summary>
        public int Dislike { get; set; }
    }
}