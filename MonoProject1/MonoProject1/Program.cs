using MonoProject1.Classes;
using System;

namespace MonoProject1
{
    class Program
    {
        static void Main(string[] args)
        {   
            string name = Console.ReadLine();

            Cat ferdo = new Cat(name);
            ferdo.AnimalSound();
            ferdo.Sleep();
            ferdo.InHouse();
            name = Console.ReadLine();
            Pet cat = new Cat(name);
            cat.PetPet();
            cat.PetTrain();
            cat.Drill();
            ferdo.Drill();
            ferdo.Outside();
            ferdo.InHouse();

            Pig amte = new Pig();
            amte.Eat();

            Human<Dog> marko = new Human<Dog>("Marko", "Štivičić");
            marko.PrintFullName();
            marko.BuyPet("Asi");
            marko.Pet.AnimalSound();
            marko.Pet.Drill();
            marko.Eat();
            marko.Pet.Run();
            marko.Say("Ang, buđenje!!");
            


            
        }
    }
}