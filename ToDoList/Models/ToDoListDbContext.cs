using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class ToDoListDbContext:DbContext
    {
        public DbSet<Register> Register { get; set; }
        public DbSet<Notes> Notes { get; set; }

        public ToDoListDbContext() : base() { }
        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    if (!builder.IsConfigured)
        //    {
        //        builder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=todolist_db;Integrated Security=True;");
        //    }
        //}
    }
}
