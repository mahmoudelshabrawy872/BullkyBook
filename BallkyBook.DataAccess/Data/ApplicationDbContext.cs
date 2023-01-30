﻿using BallkyBook.Modles;
using Microsoft.EntityFrameworkCore;

namespace BallkyBook.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; } 
        public DbSet<Product> Products { get; set; } 
    }
}