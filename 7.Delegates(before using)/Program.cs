// Seeusing System;


namespace Delegate
{

    // agreement between publisher and subcriber
    // determins the signature in the event handler


    public class PhotoFilters
    {
        public void ApplyBrightness(Photo photo)
        {
            Console.WriteLine("Apply brightness");
        }

        internal void ApplyContrast(Photo photo)
        {
            Console.WriteLine("Apply contrast");
        }

        internal void Rezise(Photo photo)
        {
            Console.WriteLine("Resize photo");
        }
    }

    public class Photo
    {
        public static Photo Load(string path)
        {
            return new Photo();
        }

        public void Save()
        {

        }

    }

    public class PhotoProcessor
    {
        public void Process(string path)
        {
            var photo = Photo.Load(path);

            var filters = new PhotoFilters(); //problem with this method is that we need to recompile this if we
                                              //want to add in more filters
            filters.ApplyBrightness(photo);
            filters.ApplyContrast(photo);
            filters.Rezise(photo);

            photo.Save();


        }
    }


    class Program

    {
        static void Main(string[] args)
        {
            var photoprocessor = new PhotoProcessor();
            photoprocessor.Process("full file path");
        }
    }

}