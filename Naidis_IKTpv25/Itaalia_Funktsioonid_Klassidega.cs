using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Naidis_IKTpv25
{
    public class Itaalia_Funktsioonid_Klassidega
    {
        static string menuuPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Menuu.txt");

        // Ainus nimekiri, mida me nüüd vajame! See hoiab mälus Menuu objekte.
        static List<Menuu> aktiivneMenuu = new List<Menuu>();

        // --- 1. ANDMETE LAADIMINE FAILIST MÄLLU ---
        public static void LaeAndmedFailist()
        {
            Console.WriteLine("\n--- 1. ANDMETE LAADIMINE ---");
            aktiivneMenuu.Clear();

            if (File.Exists(menuuPath))
            {
                foreach (string rida in File.ReadAllLines(menuuPath))
                {
                    string[] osad = rida.Split(';');
                    if (osad.Length == 3)
                    {
                        string nimi = osad[0];
                        List<string> ained = osad[1].Split(',').Select(s => s.Trim()).ToList();
                        double hind = double.Parse(osad[2].Replace('.', ','));

                        aktiivneMenuu.Add(new Menuu(nimi, ained, hind));
                    }
                }
                Console.WriteLine($"Edukalt laetud {aktiivneMenuu.Count} toitu failist mällu!");
            }
            else
            {
                Console.WriteLine("Faili ei leitud! Nimekiri on hetkel tühi.");
            }
        }

        // --- 2. KUVAMINE EHK RESTORANI MENÜÜ ---
        public static void ItaaliaRestoran()
        {
            Console.Clear();
            Console.WriteLine("===========================================");
            Console.WriteLine("          * LA BELLA ITALIA * ");
            Console.WriteLine("===========================================\n");

            if (aktiivneMenuu.Count == 0)
            {
                Console.WriteLine("Menüü on tühi! Palun lae andmed failist (Valik 1) või lisa uus toit (Valik 3).");
                return;
            }

            foreach (Menuu toit in aktiivneMenuu)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{toit.Nimetus.PadRight(30)} {toit.Hind:F2} Eur");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"   Koostis: {string.Join(", ", toit.Koostisosad)}");
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        // --- 3. UUE TOIDU LISAMINE MÄLLU ---
        public static void LisaUusToit()
        {
            Console.WriteLine("\n--- 3. UUE TOIDU LISAMINE ---");
            Console.Write("Sisesta toidu nimi (nt Lasagne): ");
            string nimi = Console.ReadLine();

            Console.WriteLine("Sisesta koostisosad ükshaaval (lõpetamiseks vajuta tühjalt Enter):");
            List<string> uuedAined = new List<string>();
            while (true)
            {
                Console.Write("Aine: ");
                string aine = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(aine)) break;
                uuedAined.Add(aine);
            }

            Console.Write("Sisesta hind (nt 12.50): ");
            double hind = double.Parse(Console.ReadLine().Replace('.', ','));

            // Loome uue Menuu objekti ja lisame mällu
            aktiivneMenuu.Add(new Menuu(nimi, uuedAined, hind));

            Console.WriteLine($"\n'{nimi}' lisati edukalt mällu! Ära unusta hiljem faili salvestada (Valik 6).");
        }

        // --- 4. TOIDU OTSIMINE ---
        public static void OtsiToitu()
        {
            Console.WriteLine("\n--- 4. OTSING ---");
            Console.Write("Sisesta toidu nimi, mida soovid otsida: ");
            string otsitav = Console.ReadLine();

            // Otsime listist objekti, mille Nimetus sisaldab otsitavat sõna (ignoreerime suur/väiketähti)
            var leitud = aktiivneMenuu.Where(t => t.Nimetus.Contains(otsitav, StringComparison.OrdinalIgnoreCase)).ToList();

            if (leitud.Count > 0)
            {
                Console.WriteLine($"\nLeidsime {leitud.Count} vastet:");
                foreach (var toit in leitud)
                {
                    Console.WriteLine($"- {toit.Nimetus} ({toit.Hind:F2} Eur)");
                }
            }
            else
            {
                Console.WriteLine($"Toitu nimega '{otsitav}' ei leitud.");
            }
        }

        // --- 5. TOIDU KUSTUTAMINE (Kasutab nüüd aktiivneMenuu listi!) ---
        public static void KustutaToit()
        {
            Console.WriteLine("\n--- 5. KUSTUTA TOIT MENÜÜST ---");
            Console.Write("Sisesta toidu nimi, mida soovid menüüst kustutada: ");
            string eemaldatav = Console.ReadLine();

            // Eemaldame aktiivsest menüüst objekti, mille Nimetus on sama
            int kustutatudArv = aktiivneMenuu.RemoveAll(t => t.Nimetus.Equals(eemaldatav, StringComparison.OrdinalIgnoreCase));

            if (kustutatudArv > 0)
            {
                Console.WriteLine($"Edukalt kustutati {kustutatudArv} kirjet nimega '{eemaldatav}'.");
            }
            else
            {
                Console.WriteLine($"Toitu nimega '{eemaldatav}' ei leitud nimekirjast.");
            }
        }

        // --- 6. ANDMETE SALVESTAMINE KETTALE ---
        public static void SalvestaFaili()
        {
            Console.WriteLine("\n--- 6. SALVESTA FAIL ---");
            try
            {
                List<string> failiRead = new List<string>();

                foreach (Menuu toit in aktiivneMenuu)
                {
                    // Vormindame iga Menuu objekti faili jaoks sobivaks tekstiks Menuu klassi meetodiga
                    failiRead.Add(toit.VormindaFailiJaoks());
                }

                File.WriteAllLines(menuuPath, failiRead);
                Console.WriteLine($"Kõik muudatused ({failiRead.Count} toitu) on edukalt faili salvestatud!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Viga salvestamisel: " + e.Message);
            }
        }
    }
}