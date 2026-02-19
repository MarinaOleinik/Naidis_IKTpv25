using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Naidis_IKTpv25
{
    public class Osa3_funktsioonid
    {
        public static Tuple<double, double, double> AnalüüsiArve(double[] arvud)
        {
            double summa = arvud.Sum();
            double keskmine = arvud.Average();
            double korrutis = 1;
            foreach (double arv in arvud)
            {
                korrutis *= arv;
            }
            return Tuple.Create(summa, keskmine, korrutis);
        }
        public static (double summa, double keskmine, double korrutis) AnalüüsiArve1(double[] arvud)
        {
            double summa = arvud.Sum();
            double keskmine = arvud.Average();
            double korrutis = 1;
            foreach (double arv in arvud)
            {
                korrutis *= arv;
            }
            return (summa, keskmine, korrutis);
        }
        public static Tuple<int, double, Inimene, Inimene> Statistika(List<Inimene> inimesed)
        {
            int summa=inimesed.Sum(i=>i.Vanus);
            double keskmine_vanus = inimesed.Average(i => i.Vanus);
            Inimene vanim = inimesed.OrderByDescending(i => i.Vanus).First();
            Inimene noorim = inimesed.OrderBy(i => i.Vanus).First();
            return Tuple.Create(summa, keskmine_vanus, noorim, vanim);
        }
        //7. Korrutustabel
        public static int[,] Korrutustabel(int read, int veerud)
        {
            int[,] tabel = new int[read, veerud];
            for (int i = 0; i < read; i++)
            {
                for (int j = 0; j < veerud; j++)
                {
                    tabel[i, j] = (i + 1) * (j + 1);
                    Console.Write($"{tabel[i, j]}\t");
                }
                Console.WriteLine();
            }
            return tabel;
        }
        //8. Õpilastega mängimine
        public static void Õpilastega_mängimine(string[] nimed)
        {
            //Asendab kolmanda ja kuuenda õpilase nime (indeksite põhjal) uue nimega "Kati" ja "Mati".
            Console.WriteLine("Uus nimi:");
            string nimi1 = Console.ReadLine();
            nimed[2] = nimi1;
            nimed[5] = "Mati";
            //Kasutab while tsüklit, et tervitada ainult õpilasi, kelle nimi algab tähega "A".
            int i = 0;
            while (i < nimed.Length)
            {
                if (nimed[i].StartsWith("A"))
                {
                    Console.WriteLine($"Tere, {nimed[i]}!");
                }
                i++;
            }
            //Kasutab for tsüklit, et väljastada kõik nimed ja nende indeksid.
            for (int j = 0; j < nimed.Length; j++)
            {
                Console.WriteLine($"Indeks: {j}, Nimi: {nimed[j]}");
            }
            //Kasutab foreach tsüklit, et väljastada kõik nimed väikeste tähtedena.
            foreach (string nimi in nimed)
            {
                Console.WriteLine(nimi.ToLower());
            }
            //Kasutab do-while tsüklit, et tervitada õpilasi seni, kuni kohtab nime "Mati".
            i = 0;
            do
            {
                if (nimed[i] == "Mati")
                {
                    Console.WriteLine("Leidsin Mati!");
                    break;
                }
                Console.WriteLine($"Tere, {nimed[i]}!");
                i++;
            }
            while (i<nimed.Length);
        }
    }
    
}
