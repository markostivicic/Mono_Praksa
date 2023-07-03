using MonoProject1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject1.Classes
{
    class Human<PetT> : Pet, IHuman<PetT>, IEatable where PetT : IAnimal, new()
    {
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                consoleWriter.Prefix = value;
            }
        }
        public string LastName { get; set; }

        public PetT Pet { get { return pet; } }

        private string firstName;
        private PetT pet;

        public Human() : base(new ConsoleWriter("John"))
        {
            FirstName = "John";
            LastName = "Doe";
        }

        public Human(string firstName, string lastName) : base(new ConsoleWriter(firstName))
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public void PrintFullName()
        {
            consoleWriter.WriteLine(GetFullName());
        }

        public void BuyPet(string name)
        {
            pet = new PetT();
            pet.Name = name;
        }

        public void Say(string message)
        {
            consoleWriter.WriteLine(message);
        }

        public void Eat()
        {
            consoleWriter.WriteLine("Go to eat");

        }

    }
}
