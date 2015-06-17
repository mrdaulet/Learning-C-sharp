using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediaStorage = new MediaStorage();
            var audioPlayer = new AudioPlayer();
            var videoPlayer = new VideoPlayer();

            var audioDelegate = new MediaStorage.PlayMedia(audioPlayer.PlayAudio);
            var videoDelegate = new MediaStorage.PlayMedia(videoPlayer.PlayVideo);

            mediaStorage.ReportResult(new AudioPlayer().PlayAudio);
            mediaStorage.ReportResult(audioDelegate);
            mediaStorage.ReportResult(videoPlayer.PlayVideo);
        }
    }

    class MediaStorage
    {
        public delegate int PlayMedia();

        public void ReportResult(PlayMedia playDelegate)
        {
            if (playDelegate() == 0)
            {
                Console.WriteLine("Success.");
            }
            else
            {
                Console.WriteLine("Fail.");
            }
        }
    }

    class AudioPlayer
    {
        private int status;

        public int PlayAudio()
        {
            Console.WriteLine("Playing audio file.");
            status = 0;
            return status;
        }
    }

    class VideoPlayer
    {
        private int status;

        public int PlayVideo()
        {
            Console.WriteLine("Playing video.");
            status = -1;
            return status;
        }
    }
}
