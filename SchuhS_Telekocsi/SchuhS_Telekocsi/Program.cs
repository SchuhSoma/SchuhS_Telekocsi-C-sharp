using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace SchuhS_Telekocsi
{
    class Program
    {
        static List<Autok> AutokList;
        static List<Igenyek> IgenyekList;
        static Dictionary<string, int> FuvarStatisztika;
        static Dictionary<string, string> SikersTalalat;
        static void Main(string[] args)
        {
            Feladat1Beolvasas(); Console.WriteLine("\n-------------------------------------\n");
            Feladat2(); Console.WriteLine("\n-------------------------------------\n");
            Feladat3(); Console.WriteLine("\n-------------------------------------\n");
            Feladat4(); Console.WriteLine("\n-------------------------------------\n");
            Feladat5(); Console.WriteLine("\n-------------------------------------\n");
            Feladat6(); Console.WriteLine("\n-------------------------------------\n");
            Console.ReadKey();
        }

        private static void Feladat6()
        {
            Console.WriteLine("6.Feladat: értesítés");
            var sw = new StreamWriter(@"utasuzenetek.txt",false,Encoding.UTF8);
            //var sw1 = new StreamWriter(@"talalat.txt", false, Encoding.UTF8);
            SikersTalalat = new Dictionary<string, string>();
            string Eredmeny = " ";
            foreach (var a in AutokList)
            {
                foreach (var i in IgenyekList)
                {
                    if (a.IndulasCel == i.IndulasCel && i.Szemelyek <= a.Ferohely)
                    {
                        Console.WriteLine("\t{0} -> Rendszám:{1}, telefonszám: {2}", i.Azonosito, a.Rendszam,a.Telefonszam);
                        Eredmeny = "Rendszám:"+a.Rendszam + "; telefonszám:" + a.Telefonszam;
                        if (!SikersTalalat.ContainsKey(i.Azonosito))
                        {
                            SikersTalalat.Add(i.Azonosito, Eredmeny);
                        }
                    }                  
                   
                }
            }
            foreach (var s in SikersTalalat)
            {
                foreach (var i in IgenyekList)
                {
                    if(s.Key==i.Azonosito)
                    {
                        Console.WriteLine("{0} -> {1}",s.Key,s.Value);
                        sw.WriteLine("{0} -> {1}", s.Key, s.Value);
                    }
                    else
                    {
                        Console.WriteLine("{0} -> Sajnos sikertelen", i.Azonosito);
                        sw.WriteLine("{0} -> Sajnos sikertelen", i.Azonosito);
                    }
                }
            }
            
        }

        private static void Feladat5()
        {
            Console.WriteLine("5.Feladat: igények és kinálat találkozása");
            foreach (var a in AutokList)
            {
                foreach (var i in IgenyekList)
                {
                    if(a.IndulasCel==i.IndulasCel && i.Szemelyek<=a.Ferohely)
                    {
                        Console.WriteLine("\t{0} -> {1}",i.Azonosito,a.Rendszam);
                    }
                }
            }
        }

        private static void Feladat4()
        {
            Console.WriteLine("4.Feladat: melyik volt az az útvonal (induló- és célállomás),\n\tamelyhez a legtöbb férőhelyet ajánlották fel a hirdetők");
            FuvarStatisztika = new Dictionary<string, int>();
            foreach (var a in AutokList)
            {
                int db = 0;
                foreach (var a1 in AutokList)
                {
                    if(a.IndulasCel==a1.IndulasCel)
                    {
                        db += a.Ferohely;
                    }
                }
                if(!FuvarStatisztika.ContainsKey(a.IndulasCel))
                {
                    FuvarStatisztika.Add(a.IndulasCel, db);
                }                
            }
            int MaxFerohely = int.MinValue;
            string MaxIndulasCel = "cica";
            foreach (var f in FuvarStatisztika)
            {
               // Console.WriteLine("\t{0,-33} - {1}",f.Key,f.Value);
               if(MaxFerohely<f.Value)
                {
                    MaxFerohely = f.Value;                  
                   
                }
                
            }
            foreach (var f in FuvarStatisztika)
            {
                if (MaxFerohely == f.Value)
                {
                    MaxIndulasCel = f.Key;
                    Console.WriteLine("\tA legtöbb férőhely: {0} , célállomás: {1} útvonalat ajánlották fel a hirdetők ", MaxFerohely, MaxIndulasCel);
                }
            }
            
        }

        private static void Feladat3()
        {
            Console.WriteLine("3.Feladat: Budapest-Miskolc hány ferőhelyet hírdettek összesen");
            int Osszes = 0;
            foreach (var a in AutokList)
            {
                if(a.Indulas=="Budapest" && a.Cel=="Miskolc")
                {
                    Osszes += a.Ferohely;
                }    
            }
            Console.WriteLine("\tAz összes férőhely a hírdetések között: {0}",Osszes);
        }

        private static void Feladat2()
        {
            Console.WriteLine("2.Feladat: hirdetők száma az állományban");
            Console.WriteLine("\tA hirdetők száma: {0}", AutokList.Count);
           
        }

        private static void Feladat1Beolvasas()
        {
            Console.WriteLine("1.Feladat: Adatok beolvasása");
            AutokList = new List<Autok>();
            IgenyekList = new List<Igenyek>();
            int dbA = 0;
            int dbI = 0;

            var sr1 = new StreamReader(@"autok.csv", Encoding.UTF8);
            while(!sr1.EndOfStream)
            {
                dbA++;
                AutokList.Add(new Autok(sr1.ReadLine()));
            }
            sr1.Close();
            if(dbA>0)
            {
                Console.WriteLine("\tAutok állomány sikeres beolvasva");
            }
            else
            {
                Console.WriteLine("\tAutok állomány sikertelen beolvasása");
            }
            var sr2 = new StreamReader(@"igenyek.csv", Encoding.UTF8);
            while (!sr2.EndOfStream)
            {
                dbI++;
                IgenyekList.Add(new Igenyek(sr2.ReadLine()));
            }
            sr2.Close();
            if (dbI > 0)
            {
                Console.WriteLine("\tIgények állomány sikeres beolvasva");
            }
            else
            {
                Console.WriteLine("\tIgények állomány sikertelen beolvasása");
            }
        }
    }
}
