using System.Text;

namespace alkatreszek
{
    class Alkatresz
    {
        public string tipus;
        public string nev;
        public string parameter;
        public int ar;

        public Alkatresz(string sor)
        {
            string[] adatok = sor.Split(";");
            tipus = adatok[0];
            nev = adatok[1];
            parameter = adatok[2];
            ar = Int32.Parse(adatok[3].Substring(adatok[3].Length-2));
        }
    }
    internal class Program
    {
        static void Alaplap()
        {
            bool megfelel = false;
            bool tobb = true;
            string nev = "";

            int ar = 0;
            string parameter = "";

            string tipus = "Alaplap";

            Console.WriteLine("Az alaplap neve:");
            nev = Console.ReadLine();

            tobb = true;
            while (tobb)
            {
                Console.WriteLine("Adja meg a paramétereit:");
                parameter += Console.ReadLine();

                Console.WriteLine("Szeretnél még paramétert megadni?(i/n)");
                string valasztas = Console.ReadLine();

                if (valasztas == "n")
                {
                    tobb = false;
                }
                if (valasztas == "i")
                {
                    parameter += ",";
                }
            }

            Console.WriteLine("Mennyibe kerül? (ft-ban, csak számot)");

            megfelel = false;
            while (!megfelel)
            {
                try
                {
                    ar = Int32.Parse(Console.ReadLine());
                    megfelel = true;
                }
                catch
                {
                    Console.WriteLine("Csak számot írhatsz be!");
                }
            }

            Fajlba_iras(tipus, nev, parameter, ar);
        }
        static void CPU()
        {
            bool megfelel = false;
            bool tobb = true;
            string nev = "";

            int ar = 0;
            string parameter = "";

            string tipus = "CPU";

            Console.WriteLine("A processzor neve:");
            nev = Console.ReadLine();

            tobb = true;
            while (tobb)
            {
                Console.WriteLine("Adja meg a paramétereit:");
                parameter += Console.ReadLine();

                Console.WriteLine("Szeretnél még paramétert megadni?(i/n)");
                string valasztas = Console.ReadLine();

                if (valasztas == "n")
                {
                    tobb = false;
                }
                if (valasztas == "i")
                {
                    parameter += ",";
                }
            }

            Console.WriteLine("Ára(ft-ban, csak számot):");

            megfelel = false;
            while (!megfelel)
            {
                try
                {
                    ar = Int32.Parse(Console.ReadLine());
                    megfelel = true;
                }
                catch
                {
                    Console.WriteLine("Csak számot írhatsz be!");
                }
            }

            Fajlba_iras(tipus, nev, parameter, ar);
        }
        static void Memoria()
        {
            bool megfelel = false;
            bool tobb = true;
            string nev = "";

            int ar = 0;
            string parameter = "";

            string tipus = "Memoria";

            Console.WriteLine("A memória neve:");
            nev = Console.ReadLine();

            tobb = true;
            while (tobb)
            {
                Console.WriteLine("Adja meg a paramétereit:");
                parameter += Console.ReadLine();

                Console.WriteLine("Szeretnél még paramétert megadni?(i/n)");
                string valasztas = Console.ReadLine();

                if (valasztas == "n")
                {
                    tobb = false;
                }
                if (valasztas == "i")
                {
                    parameter += ",";
                }
            }

            Console.WriteLine("Ára(ft-ban, csak számot):");

            megfelel = false;
            while (!megfelel)
            {
                try
                {
                    ar = Int32.Parse(Console.ReadLine());
                    megfelel = true;
                }
                catch
                {
                    Console.WriteLine("Csak számot írhatsz be!");
                }
            }

            Fajlba_iras(tipus, nev, parameter, ar);
        }
        static void GPU()
        {
            bool megfelel = false;
            bool tobb = true;
            string nev = "";

            int ar = 0;
            string parameter = "";

            string tipus = "GPU";

            Console.WriteLine("A videókártya neve:");
            nev = Console.ReadLine();

            tobb = true;
            while (tobb)
            {
                Console.WriteLine("Adja meg a paramétereit:");
                parameter += Console.ReadLine();

                Console.WriteLine("Szeretnél még paramétert megadni?(i/n)");
                string valasztas = Console.ReadLine();

                if (valasztas == "n")
                {
                    tobb = false;
                }
                if (valasztas == "i")
                {
                    parameter += ",";
                }
            }

            Console.WriteLine("Ára(ft-ban, csak számot):");

            megfelel = false;
            while (!megfelel)
            {
                try
                {
                    ar = Int32.Parse(Console.ReadLine());
                    megfelel = true;
                }
                catch
                {
                    Console.WriteLine("Csak számot írhatsz be!");
                }
            }

            Fajlba_iras(tipus, nev, parameter, ar);
        }
        static void Hattertar()
        {
            bool megfelel = false;
            bool tobb = true;
            string nev = "";

            int ar = 0;
            string parameter = "";

            string tipus = "";
            int dontes = 0;
            bool hibas = false;

            hibas = false;
            while (!hibas)
            {
                Console.WriteLine("Mi a háttértár típusa?\n1.HDD\n2.SSD");
                try
                {
                    dontes = Int32.Parse(Console.ReadLine());
                    if (dontes == 1)
                    {
                        hibas = true;
                        tipus = "HDD";
                    }
                    if (dontes == 2)
                    {
                        hibas = true;
                        tipus = "SSD";
                    }
                    if (dontes <= 0)
                    {
                        Console.WriteLine("Nem értelmezhető választás!");
                    }
                    if (dontes > 2)
                    {
                        Console.WriteLine("Nem értelmezhető választás!");
                    }
                }
                catch
                {
                    Console.WriteLine("Nem értelmezhető választás!");
                }
            }

            Console.WriteLine("A háttértár neve:");
            nev = Console.ReadLine();

            tobb = true;
            while (tobb)
            {
                Console.WriteLine("Adja meg a paramétereit:");
                parameter += Console.ReadLine();

                Console.WriteLine("Szeretnél még paramétert megadni?(i/n)");
                string valasztas = Console.ReadLine();

                if (valasztas == "n")
                {
                    tobb = false;
                }
                if (valasztas == "i")
                {
                    parameter += ",";
                }
            }

            Console.WriteLine("Mennyibe kerül? (ft-ban, csak számot)");

            megfelel = false;
            while (!megfelel)
            {
                try
                {
                    ar = Int32.Parse(Console.ReadLine());
                    megfelel = true;
                }
                catch
                {
                    Console.WriteLine("Csak számot írhatsz be!");
                }
            }

            Fajlba_iras(tipus, nev, parameter, ar);
        }
        static void Monitor()
        {
            bool megfelel = false;
            bool tobb = true;
            string nev = "";

            int ar = 0;
            string parameter = "";

            string tipus = "Monitor";

            Console.WriteLine("A monitor neve:");
            nev = Console.ReadLine();

            tobb = true;
            while (tobb)
            {
                Console.WriteLine("Adja meg a paramétereit:");
                parameter += Console.ReadLine();

                Console.WriteLine("Szeretnél még paramétert megadni?(i/n)");
                string valasztas = Console.ReadLine();

                if (valasztas == "n")
                {
                    tobb = false;
                }
                if (valasztas == "i")
                {
                    parameter += ",";
                }
            }

            Console.WriteLine("Mennyibe kerül? (ft-ban, csak számot)");

            megfelel = false;
            while (!megfelel)
            {
                try
                {
                    ar = Int32.Parse(Console.ReadLine());
                    megfelel = true;
                }
                catch
                {
                    Console.WriteLine("Csak számot írhatsz be!");
                }
            }

            Fajlba_iras(tipus, nev, parameter, ar);
        }
        static void Eger()
        {
            bool megfelel = false;
            bool tobb = true;
            string nev = "";

            int ar = 0;
            string parameter = "";

            string tipus = "Eger";

            Console.WriteLine("Az egér neve:");
            nev = Console.ReadLine();

            tobb = true;
            while (tobb)
            {
                Console.WriteLine("Adja meg a paramétereit:");
                parameter += Console.ReadLine();

                Console.WriteLine("Szeretnél még paramétert megadni?(i/n)");
                string valasztas = Console.ReadLine();

                if (valasztas == "n")
                {
                    tobb = false;
                }
                if (valasztas == "i")
                {
                    parameter += ",";
                }
            }

            Console.WriteLine("Ára(ft-ban, csak számot):");

            megfelel = false;
            while (!megfelel)
            {
                try
                {
                    ar = Int32.Parse(Console.ReadLine());
                    megfelel = true;
                }
                catch
                {
                    Console.WriteLine("Csak számot írhatsz be!");
                }
            }

            Fajlba_iras(tipus, nev, parameter, ar);
        }
        static void Billentyuzet()
        {
            bool megfelel = false;
            bool tobb = true;
            string nev = "";

            int ar = 0;
            string parameter = "";

            string tipus = "Billentyuzet";

            Console.WriteLine("A billentyűzet neve:");
            nev = Console.ReadLine();

            tobb = true;
            while (tobb)
            {
                Console.WriteLine("Adja meg a paramétereit:");
                parameter += Console.ReadLine();

                Console.WriteLine("Szeretnél még paramétert megadni?(i/n)");
                string valasztas = Console.ReadLine();

                if (valasztas == "n")
                {
                    tobb = false;
                }
                if (valasztas == "i")
                {
                    parameter += ",";
                }
            }

            Console.WriteLine("Mennyibe kerül? (ft-ban, csak számot)");

            megfelel = false;
            while (!megfelel)
            {
                try
                {
                    ar = Int32.Parse(Console.ReadLine());
                    megfelel = true;
                }
                catch
                {
                    Console.WriteLine("Csak számot írhatsz be!");
                }
            }

            Fajlba_iras(tipus, nev, parameter, ar);
        }
        static void Fajlba_iras(string tipus, string nev, string parameter, int ar)
        {
            StringBuilder iras = new StringBuilder();
            Console.WriteLine(tipus + ";" + nev + ";" + parameter + ";" + ar + "Ft" + " bekerült a fájlba!");


            Console.WriteLine("Szeretnél még alkatrészeket hozzáadni? [i/n]");
            string valasz = Console.ReadLine();

            if (valasz == "i")
            {
                iras.AppendLine(tipus + ";" + nev + ";" + parameter + ";" + ar + "Ft");
                File.AppendAllText("alkatreszek.txt", iras.ToString());
                Bevitel();
            }
            if (valasz == "n")
            {
                iras.AppendLine(tipus + ";" + nev + ";" + parameter + ";" + ar + "Ft");
                File.AppendAllText("alkatreszek.txt", iras.ToString());
                Main();
            }
        }
        static void Bevitel()
        {
            int valasztas = 0;
            bool megfelel = false;

            Console.WriteLine("Milyen alkatrészt szeretnél bevinni?");
            Console.WriteLine("-----------------------\n1.Alaplap\n2.Processzor\n3.Memória\n4.Videókártya\n5.Háttértár\n6.Monitor\n7.Egér\n8.Billentyűzet\n9.Kilépés\n-----------------------");

            megfelel = false;
            while (!megfelel)
            {
                try
                {
                    valasztas = Int32.Parse(Console.ReadLine());
                    if (valasztas > 0 && valasztas < 10)
                    {
                        megfelel = true;
                    }
                    else
                    {
                        Console.WriteLine("Nem értelmezhető választás!");
                    }
                }
                catch
                {
                    Console.WriteLine("Nem értelmezhető választás!");
                }
            }
            switch (valasztas)
            {
                case 1:
                    Alaplap();
                    break;

                case 2:
                    CPU();
                    break;

                case 3:
                    Memoria();
                    break;

                case 4:
                    GPU();
                    break;

                case 5:
                    Hattertar();
                    break;

                case 6:
                    Monitor();
                    break;

                case 7:
                    Eger();
                    break;

                case 8:
                    Billentyuzet();
                    break;

                case 9:
                    Environment.Exit(0);
                    break;
            }
        }

        static List<Alkatresz> alkatreszek = new List<Alkatresz>();

        static void TipusKereses()
        {
            Console.WriteLine("Milyen típusú alkatrészre szeretne keresni?\n-----------------------\n1.Alaplap\n2.Processzor\n3.Memória\n4.Videókártya\n5.Háttértár\n6.Monitor\n7.Egér\n8.Billentyűzet\n9.Kilépés\n-----------------------");
        }

        static void Kereses()
        {
            int valasztas = 0;
            bool megfelel = false;

            StreamReader sr = new StreamReader("alkatreszek.txt");

            string sor;

            while ((sor = sr.ReadLine()) != null)
            {
                alkatreszek.Add(new Alkatresz(sor));
            }

            Console.WriteLine("Mi alapján szeretnél keresni?\n-----------------------\n1.Típus\n2.Név\n3.Ár\n4.Akció\n-----------------------");

            megfelel = false;
            while (!megfelel)
            {
                try
                {
                    valasztas = Int32.Parse(Console.ReadLine());
                    if (valasztas > 0 && valasztas < 5)
                    {
                        megfelel = true;
                    }
                    else
                    {
                        Console.WriteLine("Nem értelmezhető választás!");
                    }
                }
                catch
                {
                    Console.WriteLine("Nem értelmezhető választás!");
                }
            }
            switch (valasztas)
            {
                case 1:
                    Bevitel();
                    break;
                case 2:
                    Kereses();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                case 4:
                    break;
            }
        }
        static void Main()
        {
            int valasztas = 0;
            bool megfelel = false;

            Console.WriteLine("Bevinni vagy keresni szeretne?\n-----------------------\n1.Bevitel\n2.Keresés\n3.Kilépés\n-----------------------");

            megfelel = false;
            while (!megfelel)
            {
                try
                {
                    valasztas = Int32.Parse(Console.ReadLine());
                    if (valasztas > 0 && valasztas < 4)
                    {
                        megfelel = true;
                    }
                    else
                    {
                        Console.WriteLine("Nem értelmezhető választás!");
                    }
                }
                catch
                {
                    Console.WriteLine("Nem értelmezhető választás!");
                }
            }
            switch (valasztas)
            {
                case 1:
                    Bevitel();
                    break;
                case 2:
                    Kereses();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}