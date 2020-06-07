using Microsoft.EntityFrameworkCore;
using Student_info.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_info.Web.Data
{
    public class UsersDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Projekt;Trusted_Connection=True;");
        }
        public DbSet<Item> Users { get; set; }
    }
}
