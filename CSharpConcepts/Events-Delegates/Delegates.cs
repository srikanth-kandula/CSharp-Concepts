using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class Delegates
    {
        private VideoEncoder vidEncoder;
        public Delegates()
        {
            vidEncoder = new VideoEncoder(); //publisher
            vidEncoder.VideoEncoded += SendEmail; //subscribe
            vidEncoder.VideoEncoded += SendTextMessage; //subscribe

            vidEncoder.VideoEncodedUsingDotNetEventHandler += SendEmail;
            vidEncoder.VideoEncodedUsingDotNetEventHandler += SendTextMessage;

            //vidEncoder.EncodeVideo(new Video("Zumanji"));
            vidEncoder.EncodeVideoInDifferentWay(new Video("Zumanji"));           
        }

        ~Delegates()
        {
            vidEncoder.VideoEncoded -= SendEmail; //unsubscribe
            vidEncoder.VideoEncoded -= SendTextMessage; //unsubscribe

            vidEncoder.VideoEncodedUsingDotNetEventHandler -= SendEmail;
            vidEncoder.VideoEncodedUsingDotNetEventHandler -= SendTextMessage;
        }

        protected void SendEmail(object src, EventArgs args)
        {
            Console.WriteLine("Sent an email");
        }

        protected void SendTextMessage(object src, EventArgs args)
        {
            Console.WriteLine("Sent a text message");
        }
    }

    class Video
    {
        public string title;
        public Video(string _title)
        {
            title = _title;
        }
    }

    class VideoEventArguments: EventArgs
    {
        public string title;
        public VideoEventArguments(string _title)
        {
            title = _title;
        }
    }

    class VideoEncoder
    {
        //step 1: Define a delegate
        //step 2: Define an event based on the delegate
        //step 3: Raise the event
        public delegate void VideoEncodedEventHandler(object source, EventArgs args);//step 1
        public Action<object, EventArgs> _VideoEncodedEventHandler;//same as step 1
        public event VideoEncodedEventHandler VideoEncoded;//step 2

        public event EventHandler<EventArgs> VideoEncodedUsingDotNetEventHandler; //equivalent to step 1 + step 2


        private Video _video;
        public void EncodeVideo(Video video)
        {
            Console.WriteLine($"{video.title} is encoded");
            OnVideoEncoded();
        }

        protected void OnVideoEncoded()
        {
            VideoEncoded(this, new VideoEventArguments(_video.title)); //step 3
        }

        public void EncodeVideoInDifferentWay(Video video)
        {
            _video = video;
            Console.WriteLine("Encoding video using dot net predefined Event Handler");
            OnVideoEncodedNew();
        }

        protected void OnVideoEncodedNew()
        {
            VideoEncodedUsingDotNetEventHandler(this, new VideoEventArguments(_video.title));
        }

    }
}
