using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolgozoProjekt
{
    class Program
    {
        static List<Dolgozo> dolgozok;

        static void Main(string[] args)
        {
            Beolvas();
            //AdatokKiirasa();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();

            Console.WriteLine("7. Feladat: Diákok száma életkor szerint csoportosítva:");
            Feladat7(15);
            Feladat7(10);
            Feladat7(17);
            Feladat7(13);
            Feladat7(11);
            Feladat7(12);
            Feladat7(16);
            Feladat7(14);

            Feladat8();

            Console.ReadKey();
        }

        private static void Beolvas()
        {
            dolgozok = new List<Dolgozo>();

            using (var sr = new StreamReader("adatok.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] sor = sr.ReadLine().Split(' ');
                    string vezeteknev = sor[0];
                    string keresztnev = sor[1];
                    string nem = sor[2];
                    int eletkor = int.Parse(sor[3]);
                    int fizetes = int.Parse(sor[4]);

                    Dolgozo dolgozo = new Dolgozo(vezeteknev, keresztnev, nem, eletkor, fizetes);
                    dolgozok.Add(dolgozo);
                }
            }
        }

        private static void AdatokKiirasa()
        {
            foreach (var dolgozo in dolgozok)
            {
                Console.WriteLine(dolgozo);
            }
        }

        private static void Feladat3()
        {
            Console.WriteLine("3. feladat: Dolgozók száma: " + dolgozok.Count);
        }

        private static void Feladat4()
        {
            int osszFizetes = 0;

            foreach (var dolgozo in dolgozok)
            {
                if (dolgozo.Eletkor < 25)
                {
                    osszFizetes = osszFizetes + dolgozo.Fizetes;
                }
            }

            Console.WriteLine("4. feladat: 25 év alattiak összfizetése: " + osszFizetes + " Ft");
        }

        private static void Feladat5()
        {
            int maxIndex = 0;
            int maxFizetes = dolgozok[0].Fizetes;

            for (int i = 0; i < dolgozok.Count; i++)
            {
                if (maxFizetes < dolgozok[i].Fizetes)
                {
                    maxFizetes = dolgozok[i].Fizetes;
                    maxIndex = i;
                }
            }

            Console.WriteLine("5. feladat: A legnagyobb fizetésű dolgozó adatai:");
            Console.WriteLine(dolgozok[maxIndex]);
        }

        private static void Feladat6()
        {
            Console.Write("6. feladat: Kérem adjon meg egy összeget: ");

            int asd = 0;
            bool szamE = int.TryParse(Console.ReadLine(), out asd);

            while (!szamE)
            {
                Console.WriteLine("Nem számot adott meg.");
                szamE = int.TryParse(Console.ReadLine(), out asd);
            }

            foreach (var dolgozo in dolgozok)
            {
                if (dolgozok.FindAll(a => a.Fizetes > asd).Count > 0)
                {
                    Console.WriteLine("\tVan olyan dolgozó, akinek a fizetése " + asd  + " Ft felett van");
                    break;
                }

                else
                {
                    Console.WriteLine("\tNincs olyan dolgozó, akinek a fizetése " + asd + " Ft felett van");
                    break;
                }
            }
        }

        private static void Feladat7(int kor)
        {
            int diakKor = 0;

            for (int i = 0; i < dolgozok.Count; i++)
            {
                if (dolgozok[i].Eletkor == kor)
                {
                    diakKor++;
                }
                
            }
            Console.WriteLine("\t" + kor + " éves: " + diakKor + " fő");

            // Linq: dolgozok.FindAll(a => a.Eletkor <= 17).GroupBy();
        }

        private static void Feladat8()
        {
            using (StreamWriter sw = new StreamWriter("diakok.txt", false, Encoding.UTF8))
            {
                foreach (var diakDolgozo in dolgozok) // dolgozok.FindAll(a => a.Eletkor <= 17)
                {
                    if (diakDolgozo.Eletkor < 18)
                    {
                        sw.WriteLine("{0} {1} {2} {3} {4} Ft", diakDolgozo.Vezeteknev, diakDolgozo.Keresztnev,
                            diakDolgozo.Nem, diakDolgozo.Eletkor, diakDolgozo.Fizetes);
                    }
                }
            }
        }
    }
}
