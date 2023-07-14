using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {

            Zoo myZoo = new Zoo();

            Habitat jungle = new Habitat("jungle");

            Animal ghost = new Lion("Ghost", 4, jungle);

            myZoo.AddHabitat(jungle);

            myZoo.FeedAllAnimals();           
            
        }
    }

    // demonstrating Abstraction
    // creating interface to achieve security, hide details
    public interface ISoundBehaviour
    {
        void MakeSound();
    }

    // creating an abstract class named Animal. 
    // creating an abstract class is a demonstration of Abstraction.
    // This is the base/parent/super class of all animals demonstrating principle of Inheritance. 
    public abstract class Animal
    {
        public Animal(string name, int age, string specie)
        {
            this.name = name;
            this.age = age;
            this.specie = specie;
        }

        // demonstration principle of Encapsulation: hiding sensitive details from users
        // using protected keyword so that it will only be accessible in this class and derived/child classes.
        // using public get and set methods to access the variable.
        protected string name; // a field
        public string Name // a property: combination of a field and method
        {
            get { return name; } // get method
            set { name = value; } // set method
        }
        protected int age { get; set; }
        protected string specie;
        public string Specie
        {
            get { return specie; }
            set { specie = value; }
        }

        // demonstration of Abstration
        // using abstract keyword to make abstract methods

        // demonstration of Polymorphism
        // overloading: same name function with different type or number of arguments.
        public abstract void Eat();
        public abstract void Eat(string food);
    }
    class Lion : Animal, ISoundBehaviour
    {
        public Lion(string animalName, int animalAge, Habitat habitat) : base(animalName, animalAge, "Lion")
        {
            habitat.AddAnimal(this);
        }
        public override void Eat()
        {
            Console.WriteLine($"{this.name} is  eating a monkey");
        }
        public override void Eat(string food)
        {
            Console.WriteLine($"{this.name} is eating {food}");
        }
        public void MakeSound()
        {
            Console.WriteLine($"{this.name} lion roars");
        }
    }

    // demonstrating Inheritance ("is-a" relation)
    // inheriting Animal class and ISoundBehaviour interface
    class Elephant : Animal, ISoundBehaviour
    {
        // principle of Inheritance
        // Construtor: base() is used to pass arguments the parent/super/base class constructor
        public Elephant(string animalName, int age, Habitat habitat) : base(animalName, age, "Elephant")
        {
            habitat.AddAnimal(this);
        }

        // principle of polymorphism
        // overriding: overriding methods defined as abstract methods in the base class.
        public override void Eat()
        {
            Console.WriteLine($"{name} the Elephant is eating peanuts");
        }
        public override void Eat(string food)
        {
            Console.WriteLine($"{name} the Elephant is eating {food}");
        }

        // principle of Abstraction: Interfaces are used to hide implementation details
        // implementing ISoundBehavour interface.
        public void MakeSound()
        {
            Console.WriteLine($"{name} the Elephant is talking abra de cabra");
        }
    }
    class Monkey : Animal, ISoundBehaviour
    {
        public Monkey(string animalName, int age, Habitat habitat) : base(animalName, age, "Monkey")
        {
            habitat.AddAnimal(this);
        }

        public override void Eat()
        {
            Console.WriteLine($"{name} the Monkey is eating a banana");
        }
        public override void Eat(string food)
        {
            Console.WriteLine($"{name} the Monkey is eating {food}");
        }

        public void MakeSound()
        {
            Console.WriteLine($"{name} the Monkey is cheering");
        }
    }

    class Habitat
    {
        public Habitat(string name)
        {
            animals = new List<Animal>();
            this.name = name;
        }
        private string name;
        private List<Animal> animals;

        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
            Console.WriteLine($"{animal.Name} the {animal.Specie} is added to {this.name}");
        }

        public List<Animal> GetAnimals()
        {
            return animals;
        }
    }

    // this Zoo class has a "has-a" relation. That means Zoo has all habitatas
    // this is an example of association specifically aggregation.
    // aggregation is weak bounding
    class Zoo
    {
        // Constructor for Zoo class
        public Zoo()
        {
            Console.WriteLine("A zoo has been created.");
        }
        private readonly List<Habitat> habitatsList = new List<Habitat>();
        public void AddHabitat(Habitat habitat)
        {
            this.habitatsList.Add(habitat);
            Console.WriteLine("The habitat is added to the zoo.");
        }
        public void FeedAllAnimals()
        {
            foreach (Habitat habitat in habitatsList)
            {
                foreach (Animal animal in habitat.GetAnimals())
                {
                    animal.Eat();
                }
            }
        }
    }
}
