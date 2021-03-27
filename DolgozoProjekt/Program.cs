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
            Feladat7();
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
                if (dolgozok.FindAll(d => d.Fizetes > asd).Count > 0)
                {
                    Console.WriteLine("Van olyan dolgozó, akinek a fizetése " + asd  + " Ft felett van");
                    break;
                }

                else
                {
                    Console.WriteLine("Nincs olyan dolgozó, akinek a fizetése " + asd + " Ft felett van");
                    break;
                }
            }
        }

        private static void Feladat7()
        {
            int diakKor14 = 0;

            foreach (var diakDolgozo in dolgozok)
            {
                if (diakDolgozo.Eletkor == 14)
                {
                    diakKor14++;
                }
                Console.WriteLine("14 éves: " + diakKor14 +  " fő");
            }
        }

        private static void Feladat8()
        {
            using (StreamWriter sw = new StreamWriter("diakok.txt", false, Encoding.UTF8))
            {
                foreach (var diakDolgozo in dolgozok)
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
