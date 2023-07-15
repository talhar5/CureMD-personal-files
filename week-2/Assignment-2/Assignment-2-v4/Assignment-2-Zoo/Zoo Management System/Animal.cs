using System;

namespace Zoo_Management_System
{
    // creating an abstract class named Animal. 
    // creating an abstract class is a demonstration of Abstraction.
    // This is the base/parent/super class of all animals demonstrating principle of Inheritance. 
    // demonstrating 'is-a' relation, inheritance: strong bounding
    // default access type: internal
    public abstract class Animal
    {
        // constructor
        // cannot be private
        protected Animal(string name, int age, string specie)
        {
            // initializing values when creating an Animal
            this.ID = Guid.NewGuid(); // assigning unique ID to each animal
            this.name = name;
            this.age = age;
            this.specie = specie;
            animalCount++;
        }

        // --> demonstration principle of Encapsulation: hiding sensitive details from users
        // using protected keyword so that it will only be accessible in this class and derived/child classes.
        // using public get and set methods to access the variable.
        public Guid ID { get; set; }
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
        private static int animalCount = 0;
        public static int AnimalCount
        {
            get { return  animalCount; }
        }
         
        // --> demonstration of Abstration
        // using abstract keyword to make abstract methods

        // --> demonstration of Polymorphism
        // overloading: same name function with different type or number of arguments.
        // default access type: private
        public abstract void Eat();
        public abstract void Eat(string food);
    }

}
