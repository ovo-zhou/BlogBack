using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) :base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Sort> Sorts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
 
    }
}
