using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;

namespace Midterm
{
    class Program
    {
        static void Main(string[] args)
        {
            SeedDatabase();
           // Problem1();
           // Problem1_2();
            Problem1_3();
        }

        public static void Problem1() 
        {
            using (var db = new AppDbContext())
            {
                var books = db.Book.ToList();
                foreach(Book b in books)
                {
                    Console.WriteLine(b);
                }
            }
        }

        public static void Problem1_2()
        {
            using (var db = new AppDbContext())
            {
                var books = db.Book.ToList();
                var apressBook = books.Where(b => b.Publisher == "Apress");
                foreach(Book b in apressBook)
                {
                    Console.WriteLine(b);
                }
            }
        }

        public static void Problem1_3()
        {
            using (var db = new AppDbContext())
            {
                var booksJoined = db.Book.Join(
                            db.Author, 
                            b => b.AuthorID,
                            a => a.AuthorID,
                            (b, a) => new
                                {
                                    Title = b.Title,
                                    Publisher = b.Publisher,
                                    AuthorFName = a.AuthorFName,
                                    AuthorLName = a.AuthorLName
                                });
                var SName = booksJoined.Min(a => a.AuthorFName);
                var SNameList = booksJoined.Where(a => a.AuthorFName == SName);
                foreach(var a in SNameList)
                {
                    Console.WriteLine(a);
                }
            }
        }

        public static void SeedDatabase()
        {
            using(var db = new AppDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                if(!db.Book.Any() && !db.Author.Any())
                {
                    IList<Author> authorList = new List<Author>()
                    {
                    new Author() { AuthorID = 1, AuthorFName = "Adam", AuthorLName = "Freeman"},
                    new Author() { AuthorID = 2, AuthorFName = "Haishi", AuthorLName = "Bai"}
                    };

                    db.Author.AddRange(authorList);
                    db.SaveChanges();
                
                    IList<Book> bookList = new List<Book>()
                    {
                    new Book() { BookID = 1, Title = "Pro ASP.NET Core MVC 2 7th ed. Edition", Publisher = "Apress", PublishDate = "October 25, 2017", Pages = 1017, AuthorID = 1},
                    new Book() { BookID = 2, Title = "Pro Angular 6 3rd Edition", Publisher = "Apress", PublishDate = "October 10, 2018", Pages = 776, AuthorID = 1},
                    new Book() { BookID = 3, Title = "Programming Microsoft Azure Service Fabric (Developer Reference) 2nd Edition", Publisher = "Microsoft Press", PublishDate = "May 25, 2018", Pages = 528, AuthorID = 2} 
                    };

                    db.Book.AddRange(bookList);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("We have existing records in the db");
                }
            }
        }
    }
}


