using MonoProject1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject1.Classes
{
    abstract class Pet : IPet
    {
        private bool _pettrain = false;
        protected IConsoleWriter _consoleWriter;

        public Pet(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }
        public void PetTrain()
        {
            if (_pettrain)
            {
                _consoleWriter.WriteLine("Pet already train");
            }
            else
            {
                _consoleWriter.WriteLine("Pet need to train");
                _pettrain = true;
            }

        }

        public void PetPet()
        {
            if (_pettrain)
            {
                _consoleWriter.WriteLine("Good boy");
                _pettrain = false;
            }
            else
            {
                _consoleWriter.WriteLine("Pet need training");

            }

        }
        public virtual void Drill()
        {
            PetTrain();
            PetPet();
        }
    }
}
