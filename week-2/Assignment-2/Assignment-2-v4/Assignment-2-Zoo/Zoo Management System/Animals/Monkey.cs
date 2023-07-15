using System;

namespace Zoo_Management_System.Animals
{
    // --> Demonstrating Inheritance ("is-a" Relation) : Strong bounding
    // inheriting Animal class and ISoundBehaviour interface
    // default access type: internal
    class Monkey : Animal, ISoundBehaviour
    {
        // --> Construtor: can be overloaded
        // base() is used to pass arguments the parent/super/base class constructor
        public Monkey(string animalName, int age, Habitat habitat) : base(animalName, age, "Monkey")
        {
            animalCount++;
            habitat.AddAnimal(this);
        }

        private static int animalCount = 0;
        public static int AnimalCount
        {
            get { return animalCount; }
            set { _ = value; }
        }


        // --> Demonstrating Polymorphism
        // overriding: overriding methods defined as abstract methods in the base class.
        // default access type: private
        public override void Eat()
        {
            Console.WriteLine($"{Name} the Monkey is eating a banana");
        }
        public override void Eat(string food)
        {
            Console.WriteLine($"{Name} the Monkey is eating {food}");
        }

        // --> Demonstrating Polymorphism
        // implementing ISoundBehavour interface. (realization)
        public void MakeSound()
        {
            Console.WriteLine($"{Name} the Monkey is cheering");
        }
    }
}
