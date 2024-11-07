using System.Text;

namespace alkatreszek
{
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
            string tipus = "CPU";

            Console.WriteLine("A processzor neve:");
            string nev = Console.ReadLine();

            Console.WriteLine("Órajele:");
            string parameter = Console.ReadLine();

            Console.WriteLine("Ára(ft-ban, csak számot):");
            int ar = Int32.Parse(Console.ReadLine());

            Fajlba_iras(tipus, nev, parameter, ar);
        }

        static void Memoria()
        {
            string tipus = "Memoria";

            Console.WriteLine("A memória neve:");
            string nev = Console.ReadLine();

            Console.WriteLine("Memória mérete:");
            string parameter = Console.ReadLine();

            Console.WriteLine("Ára(ft-ban, csak számot):");
            int ar = Int32.Parse(Console.ReadLine());

            Fajlba_iras(tipus, nev, parameter, ar);
        }

        static void GPU()
        {
            string tipus = "GPU";

            Console.WriteLine("A videókártya neve:");
            string nev = Console.ReadLine();

            Console.WriteLine("Videómemória mérete:");
            string parameter = Console.ReadLine();

            Console.WriteLine("Ára(ft-ban, csak számot):");
            int ar = Int32.Parse(Console.ReadLine());

            Fajlba_iras(tipus, nev, parameter, ar);
        }
        static void Hattertar()
        {
            string tipus = "";
            int valasztas = 0;
            bool megfelel = false;

            while (!megfelel)
            {
                Console.WriteLine("Mi a háttértár típusa?\n1.HDD\n2.SSD");
                try
                {
                    valasztas = Int32.Parse(Console.ReadLine());
                    if (valasztas == 1)
                    {
                        megfelel = true;
                        tipus = "HDD";
                    }
                    if (valasztas == 2)
                    {
                        megfelel = true;
                        tipus = "SSD";
                    }
                    if (valasztas <= 0)
                    {
                        Console.WriteLine("Nem értelmezhető választás!");
                    }
                    if (valasztas > 2)
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
            string nev = Console.ReadLine();

            Console.WriteLine("A háttértár mérete:");
            string parameter = Console.ReadLine();

            Console.WriteLine("Mennyibe kerül? (ft-ban, csak számot)");
            int ar = Int32.Parse(Console.ReadLine());

            Fajlba_iras(tipus, nev, parameter, ar);
        }
        static void Monitor()
        {
            string tipus = "Monitor";

            Console.WriteLine("A monitor neve:");
            string nev = Console.ReadLine();

            Console.WriteLine("Hány colos?");
            string parameter = Console.ReadLine();

            Console.WriteLine("Mennyibe kerül? (ft-ban, csak számot)");
            int ar = Int32.Parse(Console.ReadLine());

            Fajlba_iras(tipus, nev, parameter, ar);
        }
        static void Eger()
        {
            string tipus = "Eger";

            Console.WriteLine("Az egér neve:");
            string nev = Console.ReadLine();

            Console.WriteLine("DPI:");
            string parameter = Console.ReadLine();

            Console.WriteLine("Ára(ft-ban, csak számot):");
            int ar = Int32.Parse(Console.ReadLine());

            Fajlba_iras(tipus, nev, parameter, ar);
        }
        static void Billentyuzet()
        {
            string tipus = "Billentyuzet";

            Console.WriteLine("A billentyűzet neve:");
            string nev = Console.ReadLine();

            Console.WriteLine("Milyen switches?");
            string parameter = Console.ReadLine();

            Console.WriteLine("Mennyibe kerül? (ft-ban, csak számot)");
            int ar = Int32.Parse(Console.ReadLine());

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
            Console.WriteLine("-----------------------\n1.Alaplap\n2.Processzor\n3.Memória\n4.Grafikus kártya\n5.Háttértár\n6.Monitor\n7.Egér\n8.Billentyűzet\n9.Kilépés\n-----------------------");

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
                    if (valasztas > 0 && valasztas < 3)
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
                    Environment.Exit(0);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
