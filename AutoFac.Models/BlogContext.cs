using AutoFac.Models.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac.Models
{
    public class BlogContext:DbContext      
    {
        //private readonly string connectionstring;
        public DbSet<User> Users { get; set; }
        public BlogContext(DbContextOptions<BlogContext> options):base(options)
        {
           // connectionstring = _connectionstring;                                              
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    builder.EnableSensitiveDataLogging().UseSqlServer(connectionstring);
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new UserConfig().Configure(builder.Entity<User>());
        }


    }
}
