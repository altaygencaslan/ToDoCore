using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoCore.Data;

namespace ToDoCore.Business
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ToDoCoreDB;User Id=sa;Password=sql123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Task>()
            //            .HasOne(a => a.Reminder)
            //            .WithOne(b => b.Task)
            //            .HasForeignKey<Reminder>(b => b.Id);


        }

        public DbSet<ToDo> ToDo { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<Reminder> Reminder { get; set; }
    }
}
