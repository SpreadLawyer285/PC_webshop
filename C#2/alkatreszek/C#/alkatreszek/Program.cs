using System.Text;

namespace alkatreszek
{
    class Alkatresz
    {
        public string tipus;
        public string nev;
        public string parameter;
        public int ar;
        public int akcio;

        public Alkatresz(string sor)
        {
            string[] adatok = sor.Split(";");
            tipus = adatok[0];
            nev = adatok[1];
            parameter = adatok[2];
            string[] arak = adatok[3].Split(" ");
            ar = Int32.Parse(arak[0]);
            string[] akciok = adatok[4].Split("%");
            akcio = Int32.Parse(akciok[0]);
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

            Akcio(tipus, nev, parameter, ar);
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

            Akcio(tipus, nev, parameter, ar);
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

            Akcio(tipus, nev, parameter, ar);
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

            Akcio(tipus, nev, parameter, ar);
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

            Akcio(tipus, nev, parameter, ar);
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

            Akcio(tipus, nev, parameter, ar);
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

            Akcio(tipus, nev, parameter, ar);
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

            Akcio(tipus, nev, parameter, ar);
        }

        static void Akcio(string tipus, string nev, string parameter, int ar)
        {
            bool megfelel = false;
            int akcio = 0;
            string irando = "";
            Console.WriteLine("Akciós a termék? (i/n)");

            string valasz = Console.ReadLine();

            if (valasz == "i")
            {
                Console.WriteLine("Hány százalékos legyen?");

                megfelel = false;
                while (!megfelel)
                {
                    try
                    {
                        akcio = Int32.Parse(Console.ReadLine());
                        megfelel = true;
                    }
                    catch
                    {
                        Console.WriteLine("Csak számot írhatsz be!");
                    }
                }
            }
            irando = tipus + ";" + nev + ";" + parameter + ";" + ar + " Ft" + ";" + akcio + "%";

            Fajlba_iras(irando);
        }

        static void Fajlba_iras(string irando)
        {
            StringBuilder iras = new StringBuilder();
            Console.WriteLine(irando + " bekerült a fájlba!");


            Console.WriteLine("Szeretnél még alkatrészeket hozzáadni? [i/n]");
            string valasz = Console.ReadLine();

            if (valasz == "i")
            {
                iras.AppendLine(irando);
                File.AppendAllText("alkatreszek.txt", iras.ToString());
                Bevitel();
            }
            if (valasz == "n")
            {
                iras.AppendLine(irando);
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
            int valasztas = 0;
            bool megfelel = false;

            int osszesen = 0;

            Console.WriteLine("Milyen típusú alkatrészre szeretne keresni?\n-----------------------\n1.Alaplap\n2.Processzor\n3.Memória\n4.Videókártya\n5.HDD\n6.SSD\n7.Monitor\n8.Egér\n9.Billentyűzet\n10.Vissza\n-----------------------");

            megfelel = false;
            while (!megfelel)
            {
                try
                {
                    valasztas = Int32.Parse(Console.ReadLine());
                    if (valasztas > 0 && valasztas < 11)
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

            bool van = false;
            switch (valasztas)
            {
                case 1:
                    van = false;
                    Console.WriteLine("Alaplapok:\n-----------------------");
                    foreach (var alkatresz in alkatreszek)
                    {
                        if (alkatresz.tipus == "Alaplap")
                        {
                            osszesen++;
                            van = true;
                            Console.WriteLine("\n" + alkatresz.nev + " | " + alkatresz.parameter + " | " + alkatresz.ar + " Ft");
                        }
                    }
                    if (!van)
                    {
                        Console.WriteLine("Nincsenek elérhető alaplapjaink!");
                        TipusKereses();
                    }
                    Console.WriteLine("-----------------------");
                    break;

                case 2:
                    van = false;
                    Console.WriteLine("Processzorok:\n-----------------------");
                    foreach (var alkatresz in alkatreszek)
                    {
                        if (alkatresz.tipus == "CPU")
                        {
                            van = true;
                            Console.WriteLine("\n" + alkatresz.nev + " | " + alkatresz.parameter + " | " + alkatresz.ar + " Ft");
                        }
                    }
                    if (!van)
                    {
                        Console.WriteLine("Nincsenek elérhető processzoraink!");
                        TipusKereses();
                    }
                    Console.WriteLine("-----------------------");
                    break;

                case 3:
                    van = false;
                    Console.WriteLine("Memóriák:\n-----------------------");
                    foreach (var alkatresz in alkatreszek)
                    {
                        if (alkatresz.tipus == "Memoria")
                        {
                            van = true;
                            Console.WriteLine("\n" + alkatresz.nev + " | " + alkatresz.parameter + " | " + alkatresz.ar + " Ft");
                        }
                    }
                    if (!van)
                    {
                        Console.WriteLine("Nincsenek elérhető Memóriáink!");
                        TipusKereses();
                    }
                    Console.WriteLine("-----------------------");
                    break;

                case 4:
                    van = false;
                    Console.WriteLine("Videókártyák:\n-----------------------");
                    foreach (var alkatresz in alkatreszek)
                    {
                        if (alkatresz.tipus == "GPU")
                        {
                            van = true;
                            Console.WriteLine("\n" + alkatresz.nev + " | " + alkatresz.parameter + " | " + alkatresz.ar + " Ft");
                        }
                    }
                    if (!van)
                    {
                        Console.WriteLine("Nincsenek elérhető videókártyáink!");
                        TipusKereses();
                    }
                    Console.WriteLine("-----------------------");
                    break;

                case 5:
                    van = false;
                    Console.WriteLine("HHD-k:\n-----------------------");
                    foreach (var alkatresz in alkatreszek)
                    {
                        if (alkatresz.tipus == "HDD")
                        {
                            van = true;
                            Console.WriteLine("\n" + alkatresz.nev + " | " + alkatresz.parameter + " | " + alkatresz.ar + " Ft");
                        }
                    }
                    if (!van)
                    {
                        Console.WriteLine("Nincsenek elérhető HHD-k!");
                        TipusKereses();
                    }
                    Console.WriteLine("-----------------------");
                    break;

                case 6:
                    van = false;
                    Console.WriteLine("SSD-k:\n-----------------------");
                    foreach (var alkatresz in alkatreszek)
                    {
                        if (alkatresz.tipus == "SSD")
                        {
                            van = true;
                            Console.WriteLine("\n" + alkatresz.nev + " | " + alkatresz.parameter + " | " + alkatresz.ar + " Ft");
                        }
                    }
                    if (!van)
                    {
                        Console.WriteLine("Nincsenek elérhető SSD-k!");
                        TipusKereses();
                    }
                    Console.WriteLine("-----------------------");
                    break;

                case 7:
                    van = false;
                    Console.WriteLine("Monitorok:\n-----------------------");
                    foreach (var alkatresz in alkatreszek)
                    {
                        if (alkatresz.tipus == "Monitor")
                        {
                            van = true;
                            Console.WriteLine("\n" + alkatresz.nev + " | " + alkatresz.parameter + " | " + alkatresz.ar + " Ft");
                        }
                    }
                    if (!van)
                    {
                        Console.WriteLine("Nincsenek elérhető Monitoraink!");
                        TipusKereses();
                    }
                    Console.WriteLine("-----------------------");
                    break;

                case 8:
                    van = false;
                    Console.WriteLine("Egerek:\n-----------------------");
                    foreach (var alkatresz in alkatreszek)
                    {
                        if (alkatresz.tipus == "Eger")
                        {
                            van = true;
                            Console.WriteLine("\n" + alkatresz.nev + " | " + alkatresz.parameter + " | " + alkatresz.ar + " Ft");
                        }
                    }
                    if (!van)
                    {
                        Console.WriteLine("Nincsenek elérhető Egereink!");
                        TipusKereses();
                    }
                    Console.WriteLine("-----------------------");
                    break;

                case 9:
                    van = false;
                    Console.WriteLine("Billentyűzetek:\n-----------------------");
                    foreach (var alkatresz in alkatreszek)
                    {
                        if (alkatresz.tipus == "Billentyuzet")
                        {
                            van = true;
                            Console.WriteLine("\n" + alkatresz.nev + " | " + alkatresz.parameter + " | " + alkatresz.ar + " Ft");
                        }
                    }
                    if (!van)
                    {
                        Console.WriteLine("Nincsenek elérhető Billentyűzeteink!");
                        TipusKereses();
                    }
                    Console.WriteLine("-----------------------");
                    break;

                case 10:
                    Kereses();
                    break;
            }
            Main();
        }

        static void NevKereses()
        {
            Console.WriteLine("Írja be az adott alkatrész nevét:\n-----------------------");
            string valasztas = Console.ReadLine();
            bool van = false;
            foreach (var alkatresz in alkatreszek)
            {
                if (alkatresz.nev.ToLower().Contains(valasztas.ToLower()))
                {
                    van = true;
                    Console.WriteLine(alkatresz.tipus + " | " + alkatresz.nev + " | " + alkatresz.parameter + " | " + alkatresz.ar + " Ft");
                }
            }
            if (!van)
            {
                Console.WriteLine("Nincs ilyen nevű alkatrészünk!");
                NevKereses();
            }
            Console.WriteLine("-----------------------");
            Main();
        }

        static void ArKereses()
        {
            Console.WriteLine("Adja meg a minimum árat:");
            int min = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Adja meg a maximum árat:");
            int max = Int32.Parse(Console.ReadLine());

            bool van = false;
            foreach (var alkatresz in alkatreszek)
            {
                if (alkatresz.ar >= min && alkatresz.ar <= max)
                {
                    van = true;
                    Console.WriteLine(alkatresz.tipus + " | " + alkatresz.nev + " | " + alkatresz.parameter + " | " + alkatresz.ar + " Ft" );
                }
            }
            if (!van)
            {
                Console.WriteLine("Nincs alkatrész ennyi pénzért!");
                ArKereses();
            }
            Main();
        }

        static void AkcioKereses()
        {
            Console.WriteLine("Ezek az akciós termékeink");

            foreach (var alkatresz in alkatreszek)
            {
                if (alkatresz.akcio != 0)
                {
                    Console.WriteLine(alkatresz.akcio + "%\t" + alkatresz.tipus + "|" + alkatresz.nev + "|" + alkatresz.parameter + "|" + alkatresz.ar + " Ft");
                }
            }
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
                    TipusKereses();
                    break;
                case 2:
                    NevKereses();
                    break;
                case 3:
                    ArKereses();
                    break;
                case 4:
                    AkcioKereses();
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