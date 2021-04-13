using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ultbalaton
{
    class ubclass
    {
        internal int tavSzazalek;
        private string versenyzo;
        private int rajtszam;
        private string kategoria;
        private string versenyido;
        private int tavszazalek;

       
        public ubclass(string sor)
        {
            string[] d = sor.Split(';');
            versenyzo = d[0];
            rajtszam = Convert.ToInt32(d[1]);
            kategoria = d[2];
            versenyido = d[3];
            tavszazalek = Convert.ToInt32(d[4]);
        }

        
        public string Versenyzo { get => versenyzo; set => versenyzo = value; }
        public int Rajtszam { get => rajtszam; set => rajtszam = value; }
        public string Kategoria { get => kategoria; set => kategoria = value; }
        public string Versenyido { get => versenyido; set => versenyido = value; }
        public int TavSzazalek { get => tavszazalek; set => tavszazalek = value; }
    }
    class Program
    {
        static List<ubclass> ublista = new List<ubclass>();

        private string versenyzo;
        private int rajtszam;
        private string kategoria;
        private string versenyido;
        private int tavSzazalek;

      
       

        
        public string Versenyzo { get => versenyzo; set => versenyzo = value; }
        public int Rajtszam { get => rajtszam; set => rajtszam = value; }
        public string Kategoria { get => kategoria; set => kategoria = value; }
        public string Versenyido { get => versenyido; set => versenyido = value; }
        public int TavSzazalek { get => tavSzazalek; set => tavSzazalek = value; }

        public double idoOraban()
        {
            string[] d = versenyido.Split(':');
            double ora = Convert.ToDouble(d[0]);
            double perc = Convert.ToDouble(d[1]);
            double masodperc = Convert.ToDouble(d[2]);
            return (ora + perc / 60 + masodperc / 3600);
        }

        static void Main(string[] args)
        {
          StreamReader sr = new StreamReader("ub2017egyeni.txt", Encoding.UTF8);
            string sor = sr.ReadLine(); 
            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine();
                ubclass ub = new ubclass(sor);
                ublista.Add(ub);
            }
            sr.Close();

            Console.WriteLine("3. feladat");
            Console.WriteLine("egyéni indulók: " + ublista.Count + " fő");

            Console.WriteLine("4. feladat");
            int noiSportolo = 0;
            for (int i = 0; i < ublista.Count; i++)
            {
                if (ublista[i].Kategoria == "Noi" && ublista[i].tavSzazalek == 100)
                {
                    noiSportolo++;
                }
            }
            Console.WriteLine("Célba érkező női sportolók: " + noiSportolo + " fő");

            Console.WriteLine("5. feladat");
            Console.Write("Kérek egy sportoló nevet: ");
            string nev = Console.ReadLine();
            int index = 0;
            bool megvan = false;
            while (!megvan && index < ublista.Count)
            {
                if (ublista[index].Versenyzo == nev)
                {
                    megvan = true;
                }
                index++;
            }
            Console.Write("indult egyéniben a sportoló? ");
            if (megvan == true)
            {
                Console.WriteLine("igen");
                Console.Write("távot teljesítette-e? ");
                if (ublista[index - 1].tavSzazalek == 100)
                {
                    Console.WriteLine("igen");
                }
                else
                {
                    Console.WriteLine("Nem");
                }
            }

            Console.ReadKey();
        }
    }
}