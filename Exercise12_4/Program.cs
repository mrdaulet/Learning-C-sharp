using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise12_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var foot = new Foot(10);
            var meter = new Meter(10);

            Console.WriteLine("{0} = {1}", foot, (Meter)foot);
            Console.WriteLine("{0} = {1}", meter, (Foot)meter);

            Meter meter1 = foot;
            Foot foot1 = meter;
            Console.WriteLine(meter1);
            Console.WriteLine(foot1);            
        }
    }

    class Foot 
    {
        public double length;

        public Foot(double length)
        {
            this.length = length;
        }

        public override string ToString()
        {
            return String.Format("{0} in foot measure", length);
        }

        public static implicit operator Foot(Meter meter) 
        {
            return new Foot(meter.length / 0.3048);
        }

        public static implicit operator Meter(Foot foot)
        {
            return new Meter(foot.length * 0.3048);
        }
    }

    class Meter 
    {
        public double length;

        public Meter(double length)
        {
            this.length = length;
        }

        public override string ToString()
        {
            return String.Format("{0} in normal measure", length);
        }
    }

}
