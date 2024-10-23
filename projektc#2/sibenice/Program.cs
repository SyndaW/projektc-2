using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static string souborCesta = "slova.txt"; // Cesta k souboru se slovy

    static void Main(string[] args)
    {
        bool pokracovat = true;

        while (pokracovat)
        {
            // Načtení seznamu slov ze souboru
            List<string> slova = NactiSlova();

            // Vyber náhodné slovo
            string slovo = slova[new Random().Next(slova.Count)];
            HrajHru(slovo);

            // Po výhře nabídni přidání slova
            Console.WriteLine("Chceš přidat nové slovo do hry? (ano/ne)");
            string odpoved = Console.ReadLine();

            if (odpoved.ToLower() == "ano")
            {
                Console.Write("Zadej nové slovo: ");
                string noveSlovo = Console.ReadLine();
                PridejSlovoDoSouboru(noveSlovo);
                Console.WriteLine("Nové slovo bylo úspěšně přidáno!");
            }

            // Zeptáme se hráče, zda chce hrát znovu
            Console.WriteLine("Chceš hrát znovu? (ano/ne)");
            string znovu = Console.ReadLine();

            if (znovu.ToLower() != "ano")
            {
                pokracovat = false;
            }
        }

        Console.WriteLine("Díky za hraní!");
    }

    static List<string> NactiSlova()
    {
        List<string> slova = new List<string>();

        try
        {
            // Načti slova ze souboru
            slova = new List<string>(File.ReadAllLines(souborCesta));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Nepodařilo se načíst soubor se slovy: " + ex.Message);
        }

        return slova;
    }

    static void PridejSlovoDoSouboru(string noveSlovo)
    {
        try
        {
            // Přidej nové slovo do souboru
            using (StreamWriter sw = File.AppendText(souborCesta))
            {
                sw.WriteLine(noveSlovo);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Nepodařilo se přidat nové slovo do souboru: " + ex.Message);
        }
    }

    static void HrajHru(string slovo)
    {
        char[] hadaneSlovo = new string('_', slovo.Length).ToCharArray();
        List<char> spatneHady = new List<char>();
        int zbyvaPokusy = 14;

        while (zbyvaPokusy > 0 && new string(hadaneSlovo) != slovo)
        {


            Console.WriteLine("Hádáš: " + new string(hadaneSlovo));
            Console.WriteLine("Špatné pokusy: " + string.Join(", ", spatneHady));
            Console.WriteLine($"Zbývá {zbyvaPokusy} pokusů. Zadej písmeno:");
            
            char hadanePismeno = Console.ReadLine()[0];

            if (slovo.Contains(hadanePismeno))
            {
                for (int i = 0; i < slovo.Length; i++)
                {
                    if (slovo[i] == hadanePismeno)
                    {
                        hadaneSlovo[i] = hadanePismeno;
                    }
                }
            }
            else
            {
                spatneHady.Add(hadanePismeno);
                zbyvaPokusy--;
            }
        }

        if (new string(hadaneSlovo) == slovo)
        {
            Console.WriteLine("Gratuluji, vyhrál jsi!");
        }
        else
        {
            Console.WriteLine($"Prohrál jsi! Hledané slovo bylo: {slovo}");
        }
    }
}
