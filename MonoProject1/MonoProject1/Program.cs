using MonoProject1.Classes;
using System;

namespace MonoProject1
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat Ferdo = new Cat();
            Ferdo.AnimalSound();
            Ferdo.Sleep();
            Pet Cat = new Cat();
            Cat.PetPet();
            Cat.PetTrain();
            Cat.Drill();
            Ferdo.Drill();
            Ferdo.Outside();
            Ferdo.InHouse();

            Pig Amte = new Pig();
            Amte.Eat();

            Human<Dog> Marko = new Human<Dog>("Marko", "Štivičić");
            Marko.BuyPet("Asi");
            Marko.Pet.AnimalSound();
            Marko.Pet.Drill();
            Marko.Eat();
            Marko.Pet.Run();
            Marko.Say("Ang, buđenje!!");


            
        }
    }
}