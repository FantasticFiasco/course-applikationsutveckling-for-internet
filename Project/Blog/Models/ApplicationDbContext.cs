﻿using System.Data.Entity;

namespace Blog.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public virtual IDbSet<BlogEntry> BlogEntries { get; set; }
    }
}