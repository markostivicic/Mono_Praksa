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
        private bool pettrain = false;
        protected IConsoleWriter consoleWriter;

        public Pet(IConsoleWriter consoleWriter)
        {
            this.consoleWriter = consoleWriter;
        }
        public void PetTrain()
        {
            if (pettrain)
            {
                consoleWriter.WriteLine("Pet already train");
            }
            else
            {
                consoleWriter.WriteLine("Pet need to train");
                pettrain = true;
            }

        }

        public void PetPet()
        {
            if (pettrain)
            {
                consoleWriter.WriteLine("Good boy");
                pettrain = false;
            }
            else
            {
                consoleWriter.WriteLine("Pet need training");

            }

        }
        public virtual void Drill()
        {
            PetTrain();
            PetPet();
        }
    }
}
