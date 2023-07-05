using System.Linq;

namespace Dynamic
{

    class Program

    {
        static void Main(string[] args)
        {

            // dynamic will cause downstream to be dynamic

            dynamic a = 10;
            dynamic b = 5;
            var c = a + b;
            Console.WriteLine(c);

            dynamic excelObject = "mosh";
           // need to perform more unit test
            excelObject.Extract();




        }


    }

}
