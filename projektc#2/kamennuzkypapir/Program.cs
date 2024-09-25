using System;

namespace kamennuzkypapir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hrajeme Kámen, nůžky, papír!");
            Console.WriteLine("Zadejte svůj tah (kámen, nůžky, papír): ");
            string userChoice = Console.ReadLine();

            Random random = new Random();
            string[] choices = { "kámen", "nůžky", "papír" };
            string computerChoice = choices[random.Next(choices.Length)];

            Console.WriteLine($"Počítač zvolil: {computerChoice}");

            if (userChoice == computerChoice)
            {
                Console.WriteLine("Remíza!");
            }
            else if ((userChoice == "kámen" && computerChoice == "nůžky") ||
                    (userChoice == "nůžky" && computerChoice == "papír") ||
                    (userChoice == "papír" && computerChoice == "kámen"))
            {
                Console.WriteLine("Vyhráli jste!");
            }
            else
            {
                Console.WriteLine("Prohráli jste!");
            }

            Console.WriteLine("Stiskněte libovolnou klávesu pro ukončení...");
            Console.ReadKey();
        }
    }
}