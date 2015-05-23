using System;
using System.Collections.Generic;

namespace Exercise14
{
    abstract class Animal : IComparable<Animal>
    {
        public string Name { get; private set; }
        public int Weight { get; private set; }

        protected Animal(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }

        public abstract void Speak();
        public abstract void Move();
        public abstract new string ToString();

        public int CompareTo(Animal other)
        {
            return Weight.CompareTo(other.Weight);
        }

        public int CompareTo(Animal other, AnimalComparer.ComparisonType comparisonType)
        {
            switch (comparisonType)
            {
                case AnimalComparer.ComparisonType.Name:
                    return Name.CompareTo(other.Name);
                case AnimalComparer.ComparisonType.Weight:
                    return Weight.CompareTo(other.Weight);
            }
            return 0;
        }

        public static AnimalComparer GetComparer()
        {
            return new AnimalComparer();
        }

        public class AnimalComparer : IComparer<Animal>
        {
            public ComparisonType WhichComparison { get; set; }

            public enum ComparisonType
            {
                Name,
                Weight
            }

            public int Compare(Animal x, Animal y)
            {
                return x.CompareTo(y, WhichComparison);
            }
        }
    }

    class Dog : Animal
    {
        public Dog(string name, int weight) : base(name, weight)
        {
        }

        public override void Speak()
        {
            Console.WriteLine("{0}: Bark!", Name);
        }

        public override void Move()
        {
            Console.WriteLine("Doggy {0} moves its {1} kg of bodyweight...", Name, Weight);
        }

        public override string ToString()
        {
            return String.Format("Dog {0}, weight {1} kg", Name, Weight);
        }
    }

    class Cat : Animal
    {
        public Cat(string name, int weight) : base(name, weight)
        {
        }

        public override void Speak()
        {
            Console.WriteLine("{0}: Mew!", Name);
        }

        public override void Move()
        {
            Console.WriteLine("Cat {0} moves its {1} kg of bodyweight...", Name, Weight);
        }

        public override string ToString()
        {
            return String.Format("Cat {0}, weight {1} kg", Name, Weight);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Exercise 14-1
            var animalsArray = new Animal[4];
            animalsArray[0] = new Cat("Fluffy", 20);
            animalsArray[1] = new Dog("Sir Theodor", 50);
            animalsArray[2] = new Dog("Amiran", 14);
            animalsArray[3] = new Cat("Baks", 5);

            foreach (var animal in animalsArray)
            {
                Console.WriteLine(animal.ToString());
                animal.Move();
                animal.Speak();
                Console.WriteLine("----------------");
            }

            // Exercise 14-2
            var animalsList = new List<Animal>(animalsArray);

            Console.WriteLine("Before sort:");
            OutputCollection(animalsList);

            animalsList.Sort();
            
            Console.WriteLine("After sort:");
            OutputCollection(animalsList);


            // Exercise 14-3
            var animalsStack = new Stack<Animal>(animalsArray);
            Console.WriteLine("Stack:");
            OutputCollection(animalsStack);

            var animalsQueue = new Queue<Animal>(animalsArray);
            Console.WriteLine("Queue:");
            OutputCollection(animalsQueue);

            // Exercise 14-4
            animalsList = new List<Animal>(animalsArray);
            Console.WriteLine("Before sort:");
            OutputCollection(animalsList);

            var comparer = Animal.GetComparer();
            comparer.WhichComparison = Animal.AnimalComparer.ComparisonType.Name;
            var sortedAnimals = new List<Animal>(animalsList);
            sortedAnimals.Sort(comparer);

            Console.WriteLine("Sorted by name:");
            OutputCollection(sortedAnimals);
            

            comparer.WhichComparison = Animal.AnimalComparer.ComparisonType.Weight;
            sortedAnimals = new List<Animal>(animalsList);
            sortedAnimals.Sort(comparer);
            Console.WriteLine("Sorted by weight:");
            OutputCollection(sortedAnimals);
        }

        private static void OutputCollection(IEnumerable<Animal> animalsList)
        {
            foreach (var animal in animalsList)
            {
                Console.WriteLine(animal.ToString());
            }
            Console.WriteLine();
        }
    }
}
