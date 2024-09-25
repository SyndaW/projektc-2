using System;

namespace KamenNuzkyPapir
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

            Console.WriteLine(§"Počítač zvolil: {computerChoice}");

        }
    }
}
