using System;
using System.Collections.Generic;
using System.IO;
using Zoo_Management_System.Animals;

namespace Zoo_Management_System
{
    // this Zoo class has a "has-a" relation. That means Zoo has all habitatas
    // this is an example of association specifically aggregation.
    // aggregation is weak bounding
    // default access type: internal
    class Zoo
    {
        // Constructor for Zoo class
        public Zoo()
        {
            habitatsList = new List<Habitat>(); // initializing list
            animalsDict = new Dictionary<Guid, Animal>();
            animalCount = new Dictionary<string, int>();
            Console.WriteLine("A zoo has been created.");
        }

        // --> Demonstrating Encapsulation
        // private: to hide variale from other classes.

        // fields
        private readonly List<Habitat> habitatsList;
        private readonly Dictionary<Guid, Animal> animalsDict;
        private readonly Dictionary<string, int> animalCount;
        public int AnimalCount // total animal count in the zoo
        {
            get { return Animal.AnimalCount; }
        }

        //methods
        public void AddHabitat(Habitat habitat) // to add a habitat to the zoo
        {
            this.habitatsList.Add(habitat);

            // adding all the animals of a habitat to the Zoo animal dictionary
            foreach(KeyValuePair<Guid, Animal> animal in habitat.GetAnimalsDict())
            {
                animalsDict.Add(animal.Key, animal.Value);
            }
            Console.WriteLine($"The habitat {habitat.Name} is added to the zoo.");
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
        
        public void MakeAllAnimalsSound()
        {
            Console.WriteLine("\nMaking all animals sound\n");
            foreach(Habitat habitat in habitatsList)
            {
                foreach(Animal animal in habitat.GetAnimals())
                {
                    if(animal is ISoundBehaviour soundMakingAnimals) {
                        soundMakingAnimals.MakeSound();
                    }
                }
            }
        }

        public int GetAnimalCountByType(string animalType)
        {
            UpdateAnimalCount();
            if (animalCount.ContainsKey(animalType))
            {
                return animalCount[animalType];
            }
            else return 0;
        }

        public void UpdateAnimalCount()
        {
            foreach(Habitat habitat in habitatsList)
            {
                foreach(Animal animal in habitat.GetAnimals())
                {
                    if (animalCount.ContainsKey(animal.Specie))
                    {
                        animalCount[animal.Specie]++;
                    }
                    else animalCount[animal.Specie] = 1;
                }
            }
        }
        
    }
}
