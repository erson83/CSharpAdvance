using System;
using System.Linq;

namespace LinQ
{

    public class Book
    {
        public string Title { get; set; }
        public float Price { get; set; }

    }

    public class BookRepository
    {

        public IEnumerable<Book> GetBooks()
        {
                return new List<Book>
            {
                new Book() {Title = "Title F", Price = 5.00f },
                new Book() {Title = "Title B", Price = 9.99f },
                new Book() {Title = "Title C", Price = 12.00f },
                new Book() {Title = "Title F", Price = 13.00f }
            };

        }
    }

    class Program

    {
        static void Main(string[] args)
        {
            var books = new BookRepository().GetBooks();

            // longer method of retrieving price from list of books

            var cheapBooks = new List<Book>();
            foreach (var book in books)
            {
                if (book.Price < 10)
                    cheapBooks.Add(book);

            }
            foreach (var book in cheapBooks)
            {
                Console.WriteLine(" cheapBooks Title: " + book.Title);
            }

            // shorter method using Linq - Linq Extension Methods
            // if condition on RHS is true, it will be assigned to b
            // orderby to asecnd the book title
            // select will convert list into string
            var cheapLinqBooks = books
                .Where(b => b.Price < 10)
                .OrderBy(b => b.Title)
                .Select(b => b.Title); 
      

            foreach (var book in cheapLinqBooks)
            {
                Console.WriteLine("cheap LinQBooks Title: " + book);
            }

            // single method only returns one object
            var bookSingle = books.Single(b => b.Title == "Title C");
            Console.WriteLine("bookSingle:"  + bookSingle.Title);


            // singleorDefault method only returns true is match, false if no match
            var booksingleorDefault = books.SingleOrDefault(b => b.Title == "Title X");
            Console.WriteLine("booksingleorDefault:" + booksingleorDefault == null);


            // search for first match
            var bookFirst = books.First(b => b.Title == "Title F");
            Console.WriteLine("bookFirst Title : " + bookFirst.Title + " Price: "  + bookFirst.Price);

            // skip 2 and take 1 object onwards
            var pageBook = books.Skip(2).Take(2);

            foreach (var page in pageBook)
            {
                Console.WriteLine("pageBook: " + page.Title + " Price: " + page.Price);
            }

            // search for Max match
            var bookMax = books.Max(b => b.Price);
            Console.WriteLine("bookMax Price : " + bookMax);

            // Sum total price for all books
            var bookSum = books.Max(b => b.Price);
            Console.WriteLine("bookSum Price : " + bookSum);


            // shorter method using Linq - Linq Operator Methods
            // if condition on RHS is true, it will be assigned to b
            // orderby to asecnd the book title
            // select will convert list into string
            var cheapLinqOperatorBooks =
                from b in books
                where b.Price < 10
                orderby b.Title
                select b.Title;


            foreach (var book in cheapLinqOperatorBooks)
            {
                Console.WriteLine("Title: " + book);
            }


        }


    }

}
