using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Elephant cersie = new Elephant("Cersie", 6);
            Lion ghost = new Lion("Ghost", 5);
            Monkey marcel = new Monkey("Marcel", 1);

            ghost.Eat();
            Zoo myZoo = new Zoo();
            myZoo.AddAnimal(cersie);
            myZoo.AddAnimal(ghost);
            myZoo.AddAnimal(marcel);

            myZoo.FeedAllAnimals();

            ghost.MakeSound();
            marcel.MakeSound();
            cersie.MakeSound();

        }
    }

    public interface ISoundBehaviour
    {
        void MakeSound();
    }
    abstract class Animal
    {
        public Animal(string animalName, int animalAge, string animalSpecie)
        {
            name = animalName;
            age = animalAge;
            specie = animalSpecie;

        }

        protected string name;
        protected int age;
        protected string specie;

        public abstract void Eat();
        public abstract void Eat(string food);
    }
    class Lion : Animal, ISoundBehaviour
    {
        public Lion(string animalName, int animalAge) : base(animalName, animalAge, "Lion") { }
        public override void Eat()
        {
            Console.WriteLine($"{name} is eating a monkey");
        }
        public override void Eat(string food)
        {
            Console.WriteLine($"{name} is eating {food}");
        }
        public void MakeSound()
        {
            Console.WriteLine($"{name} lion roars");
        }
    }
    class Elephant : Animal, ISoundBehaviour
    {
        public Elephant(string animalName, int age) : base(animalName, age, "Elephant") { }
        public override void Eat()
        {
            Console.WriteLine($"{name} is eating peanuts");
        }
        public override void Eat(string food)
        {
            Console.WriteLine($"{name} is eating {food}");
        }

        public void MakeSound()
        {
            Console.WriteLine($"{name} is talking abra de cabra");
        }
    }
    class Monkey : Animal, ISoundBehaviour
    {
        public Monkey(string animalName, int age) : base(animalName, age, "Monkey") { }

        public override void Eat()
        {
            Console.WriteLine($"{name} is eating a banana");
        }
        public override void Eat(string food)
        {
            Console.WriteLine($"{name} is eating {food}");
        }

        public void MakeSound()
        {
            Console.WriteLine($"{name} is cheering");
        }
    }

    class Zoo
    {
        private readonly List<Animal> animalsList = new List<Animal>();
        public void AddAnimal(Animal animal)
        {
            animalsList.Add(animal);
            Console.WriteLine("The animal is added to the zoo.");
        }
        public void FeedAllAnimals()
        {
            foreach (Animal animal in animalsList)
            {
                animal.Eat();
            }
        }
    }
}
