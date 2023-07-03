using MonoProject1.Classes;
using MonoProject1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject1.Classes
{
    abstract class Animal : Pet, IAnimal

    {
        public abstract void AnimalSound();
        public void Sleep()
        {
            Console.WriteLine("Zzz");
        }

        public string? Name
        {
            get { return _name; }
            set
            {
                _name = value;
                _consoleWriter.Prefix = value;
            }
        }

        private string? _name;

        public Animal() : base(new ConsoleWriter("Unknown animal"))
        {

        }
        public Animal(string name) : base(new ConsoleWriter(name))
        {
            Name = name;
        }
    }
}
