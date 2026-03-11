using System;
using System.Collections.Generic;
using System.Text;

namespace Naidis_IKTpv25
{
    public class MainPageItaalia
    {
        public static void Main(string[] args)
        {
            bool tootab = true;

            while (tootab)
            {
                Console.WriteLine("\n============= PEAMENÜÜ =============");
                Console.WriteLine("1 - Salvesta lemmiktoit faili (StreamWriter)");
                Console.WriteLine("2 - Kuva kõik salvestatud toidud (StreamReader)");
                Console.WriteLine("3 - Sisesta uued koostisosad käsitsi (List)"); 
                Console.WriteLine("4 - Otsi koostisosa (Contains)");
                Console.WriteLine("5 - Salvesta koostisosad tagasi faili");
                Console.WriteLine("6 - Itaalia restorani menüü (Fail + Tuple/Fail +Class)");
                Console.WriteLine("0 - Välju");
                Console.WriteLine("====================================");


                string valik = Console.ReadLine();
                Console.Clear(); // Puhastab konsooli enne funktsiooni käivitamist

                switch (valik)
                {
                    case "1":
                        Itaalia_Funktsioonid.SalvestaRetsept();
                        break;
                    case "2":
                        Itaalia_Funktsioonid.KuvaMenuu();
                        break;
                    case "3":
                        Itaalia_Funktsioonid.SisestaKoostisosad();
                        break;
                    case "4":
                        Itaalia_Funktsioonid.OtsiKylmkapist();
                        break;
                    case "5":
                        Itaalia_Funktsioonid.SalvestaKoostisosadFaili();
                        break;
                    case "6":
                        Itaalia_Funktsioonid.ItaaliaRestoran();
                        break;
                    case "0":
                        Console.WriteLine("Programm suletud. Arrivederci!");
                        tootab = false;
                        break;
                    default:
                        Console.WriteLine("Vigane valik! Sisesta number 0 ja 6 vahel.");
                        break;
                }
            }
        }
    }
}
