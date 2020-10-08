using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.EF
{
    public class SampleAppContext : DbContext
    {
        public SampleAppContext()
        {

        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        public SampleAppContext(DbContextOptions<SampleAppContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=DESKTOP-0KLVU2P\SQLEXPRESS;Initial Catalog=SampleProductDB;Integrated Security=True");
        }


    }
}
