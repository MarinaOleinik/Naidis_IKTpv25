using System;
using System.Collections.Generic;
using System.Text;

namespace Naidis_IKTpv25
{
    public class StartPage
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("3. Osa. Kordused ja Listid, massivid");
            Console.WriteLine("For:");
            for (int i=0; i<10;i++)
            {
                Console.WriteLine($"Tere, {i+1}!");
            }
            Console.WriteLine("While:");
            int j=0;
            while (j<10)
            {
                Console.WriteLine($"Tere, {j+1}!");
                j++;
            }
            Console.WriteLine("Do:");
            do
            {
                Console.WriteLine($"Tere, {11-j}!");
                j--;
            }
            while (j!=0);
            int[] arvud = new int[5];
            Console.WriteLine("Täisarvude massiiv:");            
            arvud= Naidis_funktsioonid.Täida_massiiv(arvud);
            Naidis_funktsioonid.Massiivide_kuvamine(arvud);
            
            //Küsi mis positsioonil muuda element ja mis väärtuseks, muuda element ja kuva massiiv
            Naidis_funktsioonid.Muuda_element_massiivis(arvud);

            List<Isik> inimesed = new List<Isik>();

            for (int i = 0; i < 3; i++)
            {
                Console.Write("Sisesta nimi: ");
                string nimi = Console.ReadLine();

                Console.Write("Sisesta vanus: ");
                int vanus = int.Parse(Console.ReadLine());

                Isik uusIsik = new Isik();
                uusIsik.Nimi = nimi;
                uusIsik.Vanus = vanus;

                inimesed.Add(uusIsik);
            }

            Console.WriteLine("\nKõik inimesed tervitavad:\n");

            foreach (Isik isik in inimesed)
            {
                isik.Tervita();
            }



            //Console.OutputEncoding = Encoding.UTF8;
            //Console.WriteLine("1. Osa Andmetüübid, Alamfunktsioonid/meetodid");
            ////Console.BackgroundColor= ConsoleColor.Green;
            ////Console.ForegroundColor= ConsoleColor.Blue;
            //string tekst= "Tere tulemast C#-i maailma!";
            //Console.WriteLine($"Oli loodud muutuja tekst, mis võrdub: {tekst}");
            //Console.WriteLine("Oli loodud muutuja tekst, mis võrdub: {0}", tekst);
            //Console.Write("Mis on sinu nimi?: ");
            //string nimi = Console.ReadLine();
            ///*Console.Write("Kui vana sa oled?: ");
            //try
            //{
            //    int vanus = int.Parse(Console.ReadLine());
            //    Console.WriteLine($"Tere {nimi}. Sa oled {vanus} aastat vana");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);              
            //}
            //try
            //{
            //    Console.Write("Arv 1: ");
            //    float a = float.Parse(Console.ReadLine());
            //    Console.Write("Arv 2: ");
            //    float b = float.Parse(Console.ReadLine());
            //    float vastus = Naidis_funktsioonid.Summa(a, b);
            //    Console.WriteLine($"Summa {a} ja {b} võrdub {vastus}");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}*/

            //Random rnd = new Random();
            //int juhuslik_arv = rnd.Next(-5, 25);
            ////1.
            //Console.WriteLine(Naidis_funktsioonid.Kuu_nimetus(juhuslik_arv));
            //juhuslik_arv = rnd.Next(-5, 25);
            ////2. 
            //tekst = Naidis_funktsioonid.Kuu_nimetus(juhuslik_arv);
            //Console.WriteLine(tekst);
            ////Juku ja kino
            //Console.Write(Osa2_funktsioonid.Juku());//vaikimisi nimi= juku
            //Console.Write(Osa2_funktsioonid.Juku(nimi));
            //Console.Write(Osa2_funktsioonid.Juku("Python"));

        }



    }
}
