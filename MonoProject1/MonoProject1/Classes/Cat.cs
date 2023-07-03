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

        public Cat(string name)
        {
            this.Name = name;
        }

        private bool atHouse;

        public void InHouse()
        {
            if (atHouse)
            {
                consoleWriter.WriteLine("Already in house");
            }
            else
            {
                consoleWriter.WriteLine("Going in...");
                consoleWriter.WriteLine("House");
                atHouse = true;
            }
        }

        public void Outside()
        {
            if (atHouse)
            {
                consoleWriter.WriteLine("Go outside");
                atHouse = false;
            }
            else
            {
                consoleWriter.WriteLine("Already outside");
            }
        }

        public override void Drill()
        {
            if (atHouse)
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
