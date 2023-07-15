using System;

namespace Zoo_Management_System.Animals
{
    // --> Demonstrating Inheritance ("is-a" Relation) : Strong bounding
    // inheriting Animal class and ISoundBehaviour interface
    // default access type: internal
    class Lion : Animal, ISoundBehaviour
    {
        // --> Construtor: can be overloaded
        // base() is used to pass arguments the parent/super/base class constructor
        public Lion(string animalName, int animalAge, Habitat habitat) : base(animalName, animalAge, "Lion")
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
            Console.WriteLine($"{this.name} the Lion is  eating a monkey");
        }
        public override void Eat(string food)
        {
            Console.WriteLine($"{this.name} the Lion is eating {food}");
        }

        // --> Demonstrating Polymorphism
        // implementing ISoundBehavour interface. (realization)
        public void MakeSound()
        {
            Console.WriteLine($"{this.name} the Lion roars");
        }
    }

}
