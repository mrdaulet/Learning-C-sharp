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
            // Interestingly, this test method doesn’t actually prove that the method is acting polymorphically,
            // because you have declared the variable to be of type ElectronicPhone.
            // That means that, even if the Ring() method on Telephone WASN'T virtual, you would still get the version relevant to the sub-class.
            // To really prove that polymorphism works you need to assign your ElectricPhone to a variable declared as a Telephone
            // (which you can do even though Telephone is an abstract class - just as you would with an interface).
            Telephone phone = new ElectronicPhone();
            phone.Ring();
        }

        static void Main(String[] args)
        {
            new Program().Run();
        }
    }

    // As a general rule we try to keep different classes in different files. Obviously this is just a toy example, so less important.
    abstract class Telephone
    {
        // Your structure is what the brief told you to do. But I'd definitely choose to structure it differently.
        // I would have phoneType be an abstract property that we override directly.
        // There's not a great deal of difference but I find it to be clearer in practice
        protected abstract String phoneType { get; }

        public virtual void Ring()
        {
            Console.WriteLine("Beep-beep!");
        }

        public virtual void VoiceMail()
        {
            Console.WriteLine("You have a message. Press Play to retrieve.");
        }
    }

    //This class is identical to the DigitalPhone? Presumably that's just a typo.
    //You've also got a lot of duplication here. Some bits can be pulled into the base class.
    class ElectronicPhone : Telephone
    {
        protected override string phoneType
        {
            get { return "Electronic"; }
        }

        public override void Ring()
        {
            Console.WriteLine("Electronic Beep!");
        }

    }
    
    class DigitalPhone : Telephone
    { 
        protected override string phoneType
        {
            get { return "Digital"; }
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
        protected override string phoneType
        {
            get { return "Talking"; }
        }

        public override void Ring()
        {
            Console.WriteLine("Hey maaan, answer the call!");
        }
    }
}
