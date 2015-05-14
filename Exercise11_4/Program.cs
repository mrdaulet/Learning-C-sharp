using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise11_4
{
    class Program
    {
        private void Run()
        {
            ElectronicPhone ep = new ElectronicPhone();
            ep.Ring();
        }

        static void Main(String[] args)
        {
            Program program = new Program();
            program.Run();
        }
    }

    abstract class Telephone
    {
        protected String phoneType;

        public abstract void Ring();
    }

    class ElectronicPhone : Telephone
    {
        public ElectronicPhone()
        {
            phoneType = "Digital";
        }

        public override void Ring()
        {
            Console.WriteLine("Beep-beep!");
        }

        public void VoiceMail()
        {
            Console.WriteLine("You have a message. Press Play ro retrieve.");
        }
    }

    class DigitalPhone : Telephone
    { 
        public DigitalPhone()
        {
            phoneType = "Digital";
        }

        public override void Ring()
        {
            Console.WriteLine("Beep-beep!");
        }
        
        public virtual void VoiceMail()
        {
            Console.WriteLine("You have a message. Press Plat to retrieve.");
        }
    }

    class DigitalCellPhone : DigitalPhone
    {
        public override void VoiceMail()
        {
            Console.WriteLine("You have a message. Call to retrieve.");
        }
    }

    class TalkingPhone : Telephone
    {
        public TalkingPhone()
        {
            phoneType = "Talking";
        }

        public override void Ring()
        {
            Console.WriteLine("Hey maaan, answer the call!");
        }
    }
}
