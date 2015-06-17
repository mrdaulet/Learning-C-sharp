using System;
using System.Threading;

namespace Exercise17_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Timer();
            
            var echo1 = new Echo1();
            var echo2 = new Echo2();
            
            echo2.Subscribe(timer);
            echo1.Subscribe(timer);

            timer.Run("Some time has passed.", 2);

            timer.CountdownCompleted("Not intended to be able to run this...");
        }
    }

    class Timer
    {
        public delegate void CountdownCompletedHandler(string message);

        public CountdownCompletedHandler CountdownCompleted;

        public void Run(string message, int waitSeconds)
        {
            var timeFinish = System.DateTime.Now.AddSeconds(waitSeconds);
            for (var time = System.DateTime.Now; time < timeFinish; time = System.DateTime.Now)
            {
                Thread.Sleep(100);
            }

            if (CountdownCompleted != null)
            {
                CountdownCompleted(message);
            }
        }
    }

    class Echo1
    {
        public void Subscribe(Timer timer)
        {
            timer.CountdownCompleted += EchoMessage;
        }

        public void EchoMessage(string message)
        {
            Console.WriteLine("Echo1: {0}", message);
        }
    }

    class Echo2
    {
        public void Subscribe(Timer timer)
        {
            timer.CountdownCompleted += EchoMessage;
        }

        public void EchoMessage(string message)
        {
            Console.WriteLine("Echo2: {0}", message);
        }
    }
}
