using System;
using System.Collections.Generic;

namespace Zoo_Management_System
{
    // 'has-a' relation: association
    // Association is a relationship between two classes that allows one object instance to cause another to perform an action on its behalf.
    // --> Aggregation: habitat has a list of animals
    class Habitat
    {
        public Habitat(string name)
        {
            // creating list and dictionary when an object of Habitat is created.
            this.name = name;
            animals = new List<Animal>();
            animalsDict = new Dictionary<Guid, Animal>();
            Console.WriteLine($"A habitat is created named '{Name}'");
        }
        // variables are declared as readonly
        // readonly: can only be modified in the constructor or declaration
        private readonly string name;
        public string Name
        {
            get { return name; }
            set { _ = value; }
        }
        private readonly List<Animal> animals;
        private readonly Dictionary<Guid, Animal> animalsDict;
        public int AnimalCount
        {
            get { return animals.Count; }
            set { _ = value; }
        }

        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
            animalsDict[animal.ID] = animal;
            Console.WriteLine($"{animal.Name} the {animal.Specie} is added to the {this.name} habitat");
        }

        // method to return the dictionary of all animals
        public Dictionary<Guid, Animal> GetAnimalsDict()
        {
            return animalsDict;
        }
        public List<Animal> GetAnimals()
        {
            return animals;
        }
    }

}
