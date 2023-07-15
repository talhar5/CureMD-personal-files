using System;

namespace Zoo_Management_System.Animals
{
    // --> Demonstrating Inheritance ("is-a" Relation) : Strong bounding
    // inheriting Animal class
    // default access type: internal
    class Fish : Animal
    {
        // --> Construtor: can be overloaded
        // base() is used to pass arguments the parent/super/base class constructor
        public Fish(string animalName, int age, Habitat habitat) : base(animalName, age, "Fish")
        {
            animalCount++;
            habitat.AddAnimal(this); // interacting with the other classes: OOP
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
            Console.WriteLine($"{Name} the Fish is eating the other fishes");
        }
        public override void Eat(string food)
        {
            Console.WriteLine($"{Name} the Fish is eating {food}");
        }
    }

}
