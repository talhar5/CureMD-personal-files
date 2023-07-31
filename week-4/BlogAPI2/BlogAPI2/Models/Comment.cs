﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogAPI2.Models
{
    public class Comment
    {
        public Comment()
        {
            Post = new Post();
            User = new User();
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime PostedOn { get; set; }
        public Post Post { get; set; }
        public User User { get; set; }
    }
}