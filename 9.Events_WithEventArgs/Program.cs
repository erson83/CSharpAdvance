﻿using System;
using System.Threading;

namespace Events
{

    // loosely coupled
    // extending applications
    // communicate between objects

    public class VideoEventArgs : EventArgs    // need to declare a new class to replace default EventArgs 
    {
        public Video Video { get; set; }
    }

    public class VideoEncoder
    {
        public VideoEncoder()
        {
        }

        // 1- define a delegate
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);   // changed


        // 2- Define an event based on that delegate
        public event VideoEncodedEventHandler VideoEncoded;    // we use past tense to signal that it is done

        // 3- Raise the event

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video: " + video.Title);
            Thread.Sleep(1000);

            OnVideoEncoded(video);
        }

        protected virtual void OnVideoEncoded(Video video)  // passing in arguments here
        {
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs() {Video = video });   // use EventArgs.Empty as we not passing in any arguments
        }

    }

    public class Video
    {
        public string Title { get; set; }

        public Video()
        {
        }


    }





    class Program

    {
        static void Main(string[] args)
        {
            var video = new Video() { Title = "Video 1" };
            var videoEncoder = new VideoEncoder(); // publisher
            var mailService = new MailService(); // subscriber
            var messageService = new MessageService(); // subscriber

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;  // to register a hanlder when using +=
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;
            videoEncoder.Encode(video);


        }

        public class MailService  //subscriber 1, responsible for sending an email when video is encoded
        {
            public void OnVideoEncoded(object source, VideoEventArgs e)    // change method
            {
                Console.WriteLine("MailService: Sending an email...." + e.Video.Title);
            }
        }

        public class MessageService  //subscriber 2, responsible for sending an email when video is encoded
        {
            public void OnVideoEncoded(object source, VideoEventArgs e) // change method
            {
                Console.WriteLine("MessageService: Sending an text message...." + e.Video.Title);
            }
        }
    }
}
