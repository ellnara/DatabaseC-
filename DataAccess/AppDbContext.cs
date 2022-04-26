using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations;
using ConsoleApp17.Models;

namespace ConsoleApp17.DataAccess
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-OT3RPGF;Database=CompanyDb;Integrated Security=true;");
        }

        public DbSet<Employee> Employees { get; set; }
    }
    
     
}
