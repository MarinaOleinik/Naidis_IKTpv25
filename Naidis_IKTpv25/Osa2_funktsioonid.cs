using System;
using System.Collections.Generic;
using System.Text;

namespace Naidis_IKTpv25
{
    public class Osa2_funktsioonid
    {
        
        public static string Juku(string nimi="Juku")
        {
            string otsus = "";
            string vastus = "";
            int vanus = 0;
            string pilet = "";
            Console.WriteLine(nimi);
            if (nimi.ToLower() == "juku")
            {
                Console.Write("Kui vana sa oled?: ");
                try
                {
                    vanus = int.Parse(Console.ReadLine());
                    if (vanus > 0 && vanus<100)
                    {
                        if (vanus < 6)
                        {
                            pilet="Sulle on kinopilet tasuta!";
                        }
                        else if (vanus >= 6 && vanus < 14)
                        {
                            pilet="Sulle on kinopilet on lastepilet!";
                        }
                        else if (vanus >= 14 && vanus < 65)
                        {
                            pilet="Sulle on kinopilet täispilet!";
                        }
                        else if (vanus >= 65)
                        {
                            pilet="Sulle on kinopilet sooduspilet!";
                        }
                    }
                    else 
                    { 
                        pilet="Tundmatupilet. Vanus peab olema >0 arv ja <100!";
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                otsus= $"Lähme kinno! {pilet}";
            }
            else
            {
                otsus = "Ma olen hõivatud" ;
            } 
            vastus=$"Tere {nimi}, {otsus}";
            return vastus; 
        }   
    }
}
