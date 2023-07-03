using System;
using MonoProject1.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoProject1.Interfaces;

namespace MonoProject1.Classes
{
    class Cat : Animal, ICat
    {
        public override void AnimalSound()
        {
            Console.WriteLine("The cat says: meow");
        }

        public Cat()
        {
            _consoleWriter.Prefix = "Cat";
        }

        private bool _atHouse;

        public void InHouse()
        {
            if (_atHouse)
            {
                _consoleWriter.WriteLine("Already in house");
            }
            else
            {
                _consoleWriter.WriteLine("Going in...");
                _consoleWriter.WriteLine("House");
                _atHouse = true;
            }
        }

        public void Outside()
        {
            if (_atHouse)
            {
                _consoleWriter.WriteLine("Go outside");
                _atHouse = false;
            }
            else
            {
                _consoleWriter.WriteLine("Already outside");
            }
        }

        public override void Drill()
        {
            if (_atHouse)
            {
                GoInHouse();
            }
            else
            {
                InHouse();
                GoInHouse();
            }
        }

        private void GoInHouse()
        {
            PetTrain();
            PetPet();

        }
    }
}
