﻿using System.Xml.Linq;

namespace SpacePlace.Models
{
    public class Comment
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public Guid ParentID { get; set; }
        public Guid PosterID { get; set; }
        public string Poster { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;
        public List<Comment> Replies { get; set; } = new List<Comment>();
        public bool IsDeleted { get; set; } = false;
    }
}
