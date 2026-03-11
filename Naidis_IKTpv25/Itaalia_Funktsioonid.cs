using System;
using System.Collections.Generic;
using System.Text;

namespace Naidis_IKTpv25
{
    public class Itaalia_Funktsioonid
    {
        // Määrame failiteed klassi alguses, et need oleksid kõigile meetoditele kättesaadavad
        static string retseptidPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Retseptid.txt");
        static string koostisosadPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Koostisosad.txt");
        static string menuuPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Menuu.txt");

        // See list hoiab andmeid mälus ülesannete 3, 4 ja 5 vahel
        static List<string> koostisosadList = new List<string>();

        // --- ÜLESANNE 1 ---
        public static void SalvestaRetsept()
        {
            Console.WriteLine("\n--- 1. SALVESTA RETSEPT ---");
            try
            {
                using (StreamWriter sw = new StreamWriter(retseptidPath, true))
                {
                    Console.Write("Sisesta üks Itaalia toidu nimi (nt Lasagne): ");
                    string toit = Console.ReadLine();
                    sw.WriteLine(toit);
                } // 'using' plokk sulgeb faili automaatselt (sw.Close() pole vaja)
                Console.WriteLine("Toit edukalt salvestatud!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Viga faili kirjutamisel: " + ex.Message);
            }
        }

        // --- ÜLESANNE 2 ---
        public static void KuvaMenuu()
        {
            Console.WriteLine("\n--- 2. KUVA KOGU MENÜÜ ---");
            try
            {
                using (StreamReader sr = new StreamReader(retseptidPath))
                {
                    string koguMenüü = sr.ReadToEnd();
                    Console.WriteLine("Menüüs on hetkel järgmised toidud:");
                    Console.WriteLine(koguMenüü);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Viga faili lugemisel. Kas oled juba midagi salvestanud (Ülesanne 1)?");
            }
        }

        // --- ÜLESANNE 3 ---
        public static void MuudaKoostisosi()
        {
            Console.WriteLine("\n--- 3. MUUDA KOOSTISOSI MÄLUS ---");

            // Loome automaatselt testfaili, kui õpilasel seda veel pole
            if (!File.Exists(koostisosadPath))
            {
                File.WriteAllLines(koostisosadPath, new string[] { "Tavaline õli", "Pasta", "Ketšup", "Hakkliha" });
            }

            try
            {
                koostisosadList.Clear(); // Puhastame mälu igaks juhuks

                // Loeme failist read
                foreach (string rida in File.ReadAllLines(koostisosadPath))
                {
                    koostisosadList.Add(rida);
                }

                // Teeme muudatused
                if (koostisosadList.Count > 0)
                {
                    koostisosadList[0] = "Kvaliteetne oliiviõli";
                }
                koostisosadList.Remove("Ketšup"); // Eemaldame vale koostisosa

                Console.WriteLine("Mälus olev nimekiri on uuendatud:");
                foreach (string aine in koostisosadList)
                {
                    Console.WriteLine("- " + aine);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Viga failiga töötamisel: " + ex.Message);
            }
        }
        // --- ÜLESANNE 3 (Uuendatud: Üherealine salvestus, Kontrollib olemasolu ja uuendab) ---
        public static void SisestaKoostisosad()
        {
            Console.WriteLine("\n--- 3. SISESTA VÕI UUENDA RETSEPTI ---");

            // Eeldame, et list on juba failist loetud (vajadusel saab siia lisada faili lugemise, 
            // aga eelmiste ülesannete loogika põhjal on see mälus olemas).

            Console.Write("Millise toidu jaoks sa koostisosi lisad? (nt Risotto): ");
            string toiduNimi = Console.ReadLine();

            // 1. OTSIME, KAS TOIT ON JUBA NIMEKIRJAS OLEMAS
            int leitudIndeks = -1; // -1 tähendab, et esialgu pole leitud

            for (int i = 0; i < koostisosadList.Count; i++)
            {
                // Kontrollime, kas rida algab toidu nimega ja semikooloniga (nt "Risotto;")
                // StringComparison.OrdinalIgnoreCase tagab, et "risotto" ja "Risotto" loetakse samaks
                if (koostisosadList[i].StartsWith(toiduNimi + ";", StringComparison.OrdinalIgnoreCase))
                {
                    leitudIndeks = i; // Jätame meelde, mitmendal real see toit asub
                    break; // Lõpetame otsimise, sest leidsime üles
                }
            }

            // 2. KUVAME KASUTAJALE INFO
            if (leitudIndeks != -1)
            {
                Console.WriteLine($"\nToit '{toiduNimi}' on juba nimekirjas olemas!");
                string[] osad = koostisosadList[leitudIndeks].Split(';');
                if (osad.Length > 1)
                {
                    Console.WriteLine($"Praegused koostisosad: {osad[1]}");
                }
                Console.WriteLine("Hakkame uusi aineid juurde lisama.");
            }
            else
            {
                Console.WriteLine($"\nUus toit '{toiduNimi}'. Hakkame aineid lisama.");
            }

            // 3. KOGUME UUSI AINEID
            List<string> ajutisedAined = new List<string>();
            Console.WriteLine("Sisesta ained ükshaaval. Lõpetamiseks vajuta Enter.");

            while (true)
            {
                Console.Write("Lisa aine: ");
                string sisend = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(sisend))
                {
                    break;
                }
                ajutisedAined.Add(sisend);
            }

            // 4. SALVESTAME TULEMUSE (KAS UUENDAME VÕI LOOME UUE)
            if (ajutisedAined.Count > 0)
            {
                string uuedAinedKoos = string.Join(", ", ajutisedAined);

                if (leitudIndeks != -1)
                {
                    // A) TOIT OLI OLEMAS -> UUENDAME VANA RIDA
                    string vanaRida = koostisosadList[leitudIndeks];
                    // Paneme vana rea lõppu koma ja uued ained
                    koostisosadList[leitudIndeks] = vanaRida + ", " + uuedAinedKoos;
                    Console.WriteLine($"\nEdukalt uuendatud: {koostisosadList[leitudIndeks]}");
                }
                else
                {
                    // B) TOITU POLNUD -> LOOME TÄIESTI UUE REA
                    string tervikRida = $"{toiduNimi};{uuedAinedKoos}";
                    koostisosadList.Add(tervikRida);
                    Console.WriteLine($"\nEdukalt loodud: {tervikRida}");
                }

                Console.WriteLine("Ära unusta seda muudatust menüü valikuga nr 5 faili salvestada!");
            }
            else
            {
                Console.WriteLine("\nÜhtegi uut koostisosa ei lisatud.");
            }
        }
        // --- ÜLESANNE 4 ---
        public static void OtsiKylmkapist()
        {
            Console.WriteLine("\n--- 4. OTSING KÜLMKAPIST ---");
            if (koostisosadList.Count == 0)
            {
                Console.WriteLine("Nimekiri on tühi! Palun käivita esmalt Ülesanne 3.");
                return;
            }

            Console.Write("Mida soovid otsida? ");
            string otsitav = Console.ReadLine();

            if (koostisosadList.Contains(otsitav))
            {
                Console.WriteLine($"Jah! Koostisosa '{otsitav}' on olemas.");
            }
            else
            {
                Console.WriteLine($"Seda koostisosa ('{otsitav}') meil retseptis ei ole.");
            }
        }

        // --- ÜLESANNE 5 ---
        public static void SalvestaKoostisosadFaili()
        {
            Console.WriteLine("\n--- 5. SALVESTA UUENDATUD NIMEKIRI ---");
            if (koostisosadList.Count == 0)
            {
                Console.WriteLine("Mälus pole midagi salvestada! Käivita esmalt Ülesanne 3.");
                return;
            }

            try
            {
                File.WriteAllLines(koostisosadPath, koostisosadList);
                Console.WriteLine("Uus retsept on edukalt kettale (faili) salvestatud!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Viga salvestamisel: " + ex.Message);
            }
        }

        // --- ÜLESANNE 6 ---
        public static void ItaaliaRestoran()
        {
            Console.WriteLine("\n--- 6. ITAALIA RESTORANI MENÜÜ (TUPLE) ---");

            if (!File.Exists(menuuPath))
            {
                string[] algAndmed = {
                "Margherita pitsa;San Marzano tomatid, mozzarella, basiilik;8.50",
                "Pasta Carbonara;Spagetid, guanciale, pecorino, muna;12.00",
                "Tiramisu;Mascarpone, espresso, savoiardi;6.50"
            };
                File.WriteAllLines(menuuPath, algAndmed);
            }

            List<Tuple<string, string, double>> menyyList = new List<Tuple<string, string, double>>();
            try
            {
                foreach (string rida in File.ReadAllLines(menuuPath))
                {
                    string[] osad = rida.Split(';');
                    if (osad.Length == 3)
                    {
                        double hind = double.Parse(osad[2].Replace('.', ','));
                        menyyList.Add(Tuple.Create(osad[0], osad[1], hind));
                    }
                }
                Console.Clear();
                Console.WriteLine("===========================================");
                Console.WriteLine("          * LA BELLA ITALIA *          ");
                Console.WriteLine("===========================================\n");
                foreach (var toit in menyyList)
                {
                    Console.WriteLine($"{toit.Item1.PadRight(30)} {toit.Item3:F2} Eur");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"   Koostis: {toit.Item2}");
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Viga restoranimenüü töötlemisel: " + ex.Message);
            }
        }
        
        
    }
}
