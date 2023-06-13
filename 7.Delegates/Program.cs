// Seeusing System;


namespace Delegate
{

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

        internal void Resize(Photo photo)
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
        public delegate void PhotoFilterHandler(Photo photo); // added in the delegate here

        public void Process(string path, Action<Photo> filterHandler)
        {
            var photo = Photo.Load(path);

            var filters = new PhotoFilters(); //problem with this method is that we need to recompile this if we
                                              //want to add in more filters

            //filters.ApplyBrightness(photo);           // removed these parts for delegate, not required anymore
            //filters.ApplyContrast(photo);
            //filters.Rezise(photo);

            filterHandler(photo);

            photo.Save();


        }
    }


    class Program

    {   // use delegate when design pattern is used
        // use delegate when caller does not need to access other properties or methods on the object implementing the method

        static void Main(string[] args)
        {
            var photoprocessor = new PhotoProcessor();
            var filters = new PhotoFilters();
            Action<Photo> filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += filters.Resize;
            filterHandler += RemoveRedEyeFilter;    // do not need to call filters.

            photoprocessor.Process("full file path", filterHandler);
        }

        static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("Apply RemoveRedEye");   // added in new delegate here without editin the code in classes;
        }
    }

}