using System;
using MonoProject1.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoProject1.Interfaces;

namespace MonoProject1.Classes
{
    class Pig : Animal, IEatable, IPig
    {
        public override void AnimalSound()
        {
            Console.WriteLine("The pig says: wee wee");
        }

        public void Eat()
        {
            WalkToFood();
            _consoleWriter.WriteLine("Eating");
        }

        public void WalkToFood()
        {
            _consoleWriter.WriteLine("Walking to food");

        }
    }
}
