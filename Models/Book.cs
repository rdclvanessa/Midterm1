using System;

namespace Midterm
{
    public class Book
    {
        public int BookID{get;set;}
        public string Title{get;set;}
        public string PublishDate{get;set;}
        public string Publisher{get;set;}
        public double Pages{get;set;}
        public int AuthorID{get;set;}

    public override string ToString()
    {
        return this.Title + " : " + this.Publisher;
    }

    }
}