using System;
using Zoo_Management_System.Animals;

namespace Zoo_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {

            Zoo myZoo = new Zoo(); // creating a zoo
            Console.WriteLine();
            Habitat jungle = new Habitat("jungle"); // creating habitats
            Habitat water = new Habitat("water");
            Console.WriteLine();

            // creating animals of different species
            // animals will be added to the respective habitats automatically
            Animal ghost = new Lion("Ghost", 4, jungle);
            Animal cersie = new Elephant("Cersie", 4, jungle);
            Animal giant = new Elephant("Giant", 4, jungle);
            Animal mercey = new Fish("Mercey", 4, water);
            Animal marcel = new Monkey("Marcel", 4, jungle);
            Console.WriteLine();

            // adding habitats to the zoo
            myZoo.AddHabitat(jungle);
            myZoo.AddHabitat(water);
            Console.WriteLine();

            myZoo.FeedAllAnimals();
            Console.WriteLine();

            // checking total animal count in the jungle
            Console.WriteLine("Animal count in jungle habitat: {0}", jungle.AnimalCount);
            Console.WriteLine();
            myZoo.MakeAllAnimalsSound(); // making animals sound
            Console.WriteLine();

            // getting animal count by type
            Console.WriteLine("Number of Elephants: {0}", myZoo.GetAnimalCountByType("Elephant"));
            

            // total animal count in the zoo
            Console.WriteLine("Animal count in the zoo: {0}", myZoo.AnimalCount);
            Console.ReadKey();

        }
    }
}
