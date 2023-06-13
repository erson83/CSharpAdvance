using System;

namespace ExtensionsMethods
{

    class Program

    {
        static void Main(string[] args)
        {
            var post = "This is supposed to be a long statement ..................";
            var shortenedPost = post.Shorten(5);


            Console.WriteLine(shortenedPost);

            var numbers = new List<int>() {1,4,6,9 };

            Console.WriteLine(numbers.Max());  // Max is an extension
        }

        
    }

    public static class StringExtensions
    {

        public static string Shorten(this String str, int numberOfWords)
        {

            if (numberOfWords < 0)
                throw new ArgumentOutOfRangeException("number of words should be greater than 0");

            if (numberOfWords == 0)
                return "";

            var words = str.Split(' ');
            if (words.Length <= numberOfWords)
                return str;
            return string.Join(" ", words.Take(numberOfWords));    // take is an extension, returning specific no.

        }


    }
}
