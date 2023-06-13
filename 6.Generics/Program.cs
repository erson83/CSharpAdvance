using System;


namespace Numerics
{
    public class List
    {
        public void Add(int number)
        {
            throw new NotImplementedException();
        }


        //The indexer: The class defines an indexer, which allows instances of the class to be accessed using square
        //brackets, similar to an array. However, in this case, the indexer also throws a "NotImplementedException".

        public int this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }



    public class BookList
    {
        public void Add(Book book)
        {
            throw new NotImplementedException();
        }

        public Book this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }



    public class GenericList<T>
    {
        public void Add(T value)
        {

        }

        public T this[int index]
        {
            get { throw new NotImplementedException(); }
        }

    }

    public class GenericDictionary<TKey, TValue>
    {
        public void Add(TKey key, TValue value)
        {

        }
    }



    class Program

    {
        static void Main(string[] args)
        {
            var book = new Book { Isbn = "qqqq", Title = "C#" };

            var dictionary = new GenericDictionary<string, Book>();
            dictionary.Add("1234", new Book());

            var genericList = new GenericList<int>();
            genericList.Add(10);

            var numbers = new List();
            numbers.Add(10);

            var books = new BookList();
            books.Add(book);

            var numbersAlt = new GenericList<int>();    // we rarely create generic classes, usually use part of .net generic list
            numbersAlt.Add(10);

            var booksAlt = new GenericList<BookList>();
            booksAlt.Add(new BookList());

        }
    }

}