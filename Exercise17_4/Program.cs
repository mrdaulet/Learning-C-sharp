using System;
using System.Threading;

namespace Exercise17_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Timer();

            timer.CountdownCompleted += message => Console.WriteLine("Lambda1: {0}", message);
            timer.CountdownCompleted += (message) => { Console.WriteLine("Lambda2: {0}", message); };

            timer.Run("Some time has passed.", 2);
        }
    }

    class Timer
    {
        public delegate void CountdownCompletedHandler(string message);

        public event CountdownCompletedHandler CountdownCompleted;

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
}
