using System;

namespace Midterm
{
    public class Author
    {
        public int AuthorID{get;set;}
        public string AuthorFName{get;set;}
        public string AuthorLName{get;set;}

        public override string ToString()
    {
        return this.AuthorFName + " " + this.AuthorLName;
    }

    }
}