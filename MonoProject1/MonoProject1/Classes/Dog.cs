using MonoProject1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject1.Classes
{
    class Dog : Animal, IDog, IEatable
    {
            public void Eat()
            {
                WaveTail();
                AnimalSound();
                _consoleWriter.WriteLine("Eating");
            }

            public void WaveTail()
            {
                _consoleWriter.WriteLine("Wave tail");
            }

            public void Run()
            {
                _consoleWriter.WriteLine("Runing around and geting tired");
                Sleep();
            }


            public override void AnimalSound()
            {
                _consoleWriter.WriteLine("Wuf, wuf");
            }
        }
}
