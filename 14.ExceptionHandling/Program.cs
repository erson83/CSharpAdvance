using System.IO;
using System.Linq;

namespace Dynamic
{
    public class Video
    {

    }


    public class YoutubeException : Exception
    {
        public YoutubeException(string message, Exception innerException)
            :base(message, innerException)
        {

        }


    }

    public class YouTubeApi

    {
        public List<Video> GetVideos(string user)
        {
            try
            {
                // access youtube web service
                // read data
                // create a list of video objects
                throw new Exception("some random error");
            }
            catch (Exception ex)
            {
                // log
                throw new YoutubeException("Could not fetch the videos", ex);
            }

        }



    }


    public class Calculator
    {
        public int A;
        public int B;

        public Calculator()
        {
        }

        public Calculator(int a, int b)
        {
            this.A = a;
            this.B = b;

        }

        public int Divide(int a, int b)
        {
            return a / b;

        }


    }


    class Program

    {
        static void Main(string[] args)
        {
            try
            {
                var api = new YouTubeApi();
                var videos =  api.GetVideos("mosh");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



            try
            {
                var calculator = new Calculator();

                var result = calculator.Divide(5,0);
                Console.WriteLine(result);



                
            }

            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Cannot divide by zero");

            }

            catch (ArithmeticException ex)
            {


            }

            catch (Exception ex)
            {
                Console.WriteLine("Error message:" + ex.Message);
            }


            finally
            {
                // to manually do a clean up
                // Idisposable

                
            }

            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(@"C:\xxxxx");
                var content = streamReader.ReadToEnd();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found");
            }

            catch (Exception ex)
            {
                Console.WriteLine("cannot read file");
            }

            finally
            {

                // to manually do a cleanup because streamrader is using up resources.
                if (streamReader != null)
                streamReader.Dispose();
            }


            // alternative method USING, it will call a Finally block at the end for streamreader

            try
            {
                using (var streamReader2 = new StreamReader(@"C:\xxxxx"))

                {
                    var content = streamReader2.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found");
            }

            catch (Exception ex)
            {
                Console.WriteLine("cannot read file");
            }




        }


    }

}
