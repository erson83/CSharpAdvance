using System;
using System.Linq;

namespace Nullable
{

    class Program

    {
        static void Main(string[] args)
        {

            // the question mark (?) is used to indicate that a variable of a
            // value type can also have a null value. This feature is known as nullable value types.
            DateTime? date = null;

            Console.WriteLine(date.GetValueOrDefault());
            Console.WriteLine(date.HasValue);
            try
            {
                Console.WriteLine(date.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine("date having issues writing nullable value");
            }


            DateTime? date2 = new DateTime(1992, 11, 01);
            DateTime date3 = date2.GetValueOrDefault();
            Console.WriteLine(date3);



            // longer method
            DateTime? date4 = new DateTime(1992,1,1);
            DateTime date4a;
            if (date4 != null)
                date4a = date4.GetValueOrDefault();
            else
                date4a = DateTime.Today;

            Console.WriteLine(date4a);

            // shorter method - coalescing operator
            DateTime? date5 = new DateTime(1992, 1, 1);
                    // if date5 is true, then assign to date5a
                    // else assign DateTime.Today to date5a
            DateTime date5a = date5 ?? DateTime.Today;
            Console.WriteLine(date5a);

            // another shorter method - tierary operator
            DateTime? date6 = new DateTime(1992, 1, 1);
            // if date6 is true, then assign to date6a
            // else assign DateTime.Today to date6a
            DateTime date6a = (date6 != null) ? date6.GetValueOrDefault() : DateTime.Today;
            Console.WriteLine(date6a);

        }


    }

}
