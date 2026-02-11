using System;
using System.Collections.Generic;
using System.Text;

namespace Naidis_IKTpv25
{
    public class Naidis_funktsioonid
    {
        public static float Summa(float arv1, float arv2)
        {
            return arv1 + arv2;
        }
        public static string Kuu_nimetus(int kuu_nr)
        {
            string kuu = "";
            switch (kuu_nr)
            {
                case 1: kuu = "Jaanuar"; break;
                case 2: kuu = "Veebruar"; break;
                case 3: kuu = "Märts"; break;
                case 4: kuu = "Aprill"; break;
                case 5: kuu = "Mai"; break;
                case 6: kuu = "Juuni"; break;
                case 7: kuu = "Juuli"; break;
                case 8: kuu = "August"; break;
                case 9: kuu = "September"; break;
                case 10: kuu = "Oktoober"; break;
                case 11: kuu = "Novemberr"; break;
                case 12: kuu = "Detsember"; break;

                default:
                    kuu = "???";
                    break;
            }
            return kuu;
        }

        public static string Hooaeg(int kuu_nr)
        {
            string hoo = "";
            if (kuu_nr == 1 || kuu_nr == 2 || kuu_nr == 12) //&& - and, || - or
            {
                hoo = "Talv";
            }
            else if (kuu_nr > 2 && kuu_nr < 6)
            {
                hoo = "Kevad";
            }
            else if (kuu_nr > 5 && kuu_nr < 9)
            {
                hoo = "Suvi";
            }
            else if (kuu_nr > 8 && kuu_nr < 12) //9,10,11
            {
                hoo = "Sügis";
            }
            else
            {
                hoo = "???";
            }
            return hoo;
        }

        
        public static void Muuda_element_massiivis(int[] arvud)
        {
            Console.WriteLine("Kuhu: ");
            int positsioon = int.Parse(Console.ReadLine());
            Console.WriteLine("Milliseks: ");
            int uus_arv = int.Parse(Console.ReadLine());
            arvud[positsioon - 1] = uus_arv;
            Console.WriteLine("Uuendatud massiiv: ");
            for (int i = 0; i < arvud.Length; i++)
            {
                Console.WriteLine($"Sisestatud arv: {arvud[i]}");
            }
        }
        public static int[] Täida_massiiv(int[] arvud)
        {
            for (int i = 0; i < arvud.Length; i++)
            {
                Console.Write($"Sisesta {i + 1}. arv: ");
                try
                {
                    arvud[i] = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return arvud;
        }
        public static void Massiivide_kuvamine(int[] arvud)
        {
            Console.WriteLine("Foreach abil:");
            foreach (int arv in arvud)
            {
                Console.WriteLine($"Sisestatud arv: {arv}");
            }
            Console.WriteLine("For abil: esimene-> viiname");
            for (int i = 0; i < arvud.Length; i++)
            {
                Console.WriteLine($"Sisestatud arv: {arvud[i]}");
            }
            Console.WriteLine("For abil: viimane-> esimene");
            for (int i = arvud.Length - 1; i > -1; i--)
            {
                Console.WriteLine($"Sisestatud arv: {arvud[i]}");
            }
        }
    }
}
