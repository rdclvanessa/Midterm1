using System; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Midterm
{
    //here we extend the DbContext class without own class 'AppDbContext'
    public class AppDbContext : DbContext
    {
        //the connection string is used by the SQL Server database provider to find the database
        private const string ConnectionString = @"Data Source=Midterm.db";


        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            //Using the SQLite database provider's UseSqlServer command sets up the options ready for creating
            optionsBuilder.UseSqlite(ConnectionString); //#8
        }
        public DbSet<Book> Book {get; set;}
        public DbSet<Author> Author {get; set;}
    }
}