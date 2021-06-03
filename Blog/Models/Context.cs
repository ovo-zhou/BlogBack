using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        //用户表
        public DbSet<User> Users { get; set; }
        //文章类别表
        public DbSet<Sort> Sorts { get; set; }
        //文章表
        public DbSet<Blog> Blogs { get; set; }
        //留言表
        public DbSet<Message> Messages { get; set; }
    }
}
