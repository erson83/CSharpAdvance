using System;


namespace Numerics
{
    public class Book
    {
        public string Title { get; set; }
        public int Price { get; set; }
    }

    public class BookRepository
    {
        public List<Book> GetBooks()
        {
            return new List<Book>

            {

                new Book() {Title = "A", Price = 5 },
                new Book() {Title = "B", Price = 7  },
                new Book() {Title = "C", Price = 17  }

            };


        }


    }




    class Program

    {
        static void Main(string[] args)
        {

            //args => expression
            Func<int, int> Square = number => number * number;     // similar to the static int below
            Console.WriteLine(Square(5));

            const int factor = 5;
            Func<int, int> multiplier = n => n * factor;
            Console.WriteLine(multiplier(10));

            var books = new BookRepository().GetBooks();
            var cheapbooks = books.FindAll(book => book.Price < 10);

            //var cheapbooks = books.FindAll(IsCheaperThan10Dollars);       // similar to static bool below
            

            foreach (var item in cheapbooks)
            {
                Console.WriteLine("Item lesser than 10 dollars: " + item.Title);
            }

        }

        //static bool IsCheaperThan10Dollars(Book book)
        //{
        //    return book.Price < 10;
        //}

        //static int Square(int number)
        //{
        //    return number * number;
        //}
    }

}