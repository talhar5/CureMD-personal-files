﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogAPI2.Models
{
    public class Category
    {
        public Category()
        {
            Posts = new List<Post>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Post> Posts { get; set; }
    }
}