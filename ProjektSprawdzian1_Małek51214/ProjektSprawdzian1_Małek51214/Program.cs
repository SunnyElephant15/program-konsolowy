using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1_Malek51214
{
    class Program
    {
        static bool MojeTryParseLiczbaDziesietna(string ZnakowyZapisLiczby, out short LiczbaPoKonwersji)
        {
            int N;
            short L;
            char Cyfra;
            short PSL_LiczbyDoKonwersji = 10;
            short IndexPierwszejCyfry = 0;

            ZnakowyZapisLiczby = ZnakowyZapisLiczby.Trim();

            N = ZnakowyZapisLiczby.Length;
            L = 0;
            for (int i = IndexPierwszejCyfry; i < N; i++)
            {
                Cyfra = ZnakowyZapisLiczby[i];
                if ((Cyfra >= '0') && ((Cyfra - '0') < PSL_LiczbyDoKonwersji))
                {
                    L = (short)((L * PSL_LiczbyDoKonwersji) + (Cyfra - '0'));
                }
                else
                {
                    LiczbaPoKonwersji = 0;
                    return false;
                }
            }
            LiczbaPoKonwersji = L;
            return true;
        }

        static void KonwersjaLiczbyNaSystemDwójkowy(short Liczba, byte PodstawaSystemuLiczbowego, out string ZnakowyZapisLiczby)
        {
            short Licznik = 0;
            string SchowekReszt = "";
            byte Reszta;
            while (Liczba > 0)
            {
                Reszta = (byte)(Liczba % PodstawaSystemuLiczbowego);
                SchowekReszt = SchowekReszt + (char)(Reszta + '0');
                Licznik++;
                Liczba = (short)(Liczba / PodstawaSystemuLiczbowego);
            }
            ZnakowyZapisLiczby = "";
            for (int i = Licznik - 1; i >= 0; i--)
            {
                ZnakowyZapisLiczby = ZnakowyZapisLiczby + SchowekReszt[i];
            }

        }


        static void Main(string[] args)
        {
            ConsoleKeyInfo WybranaFunkcjalnosc;
            Console.WriteLine("\n\tProgram obliczenia wybranej wartości");
            do
            {
                Console.WriteLine("\n\n\t\t\tMenu (funkcjonalme) PROGRAMU:\n");
                Console.WriteLine("\n\tA. Obliczenie pierwiastków równania kwadratowego");
                Console.WriteLine("\n\tB. Obliczenie wartości wielomianu n-tego stopnia");
                Console.WriteLine("\n\tC. Konwersja liczby naturalnej z zapisu dziesiętnego na zapis w systemie dwójkowym");
                Console.WriteLine("\n\tD. Obliczenie ceny paszy");
                Console.WriteLine("\n\tE. Obliczanie średniej harmonicznej");
                Console.WriteLine("\n\tF. Obliczanie średniej geometrycznej");
                Console.WriteLine("\n\tG. Obliczanie średniej kwadratowej");
                Console.WriteLine("\n\tH. Obliczanie średniej potęgowej");
                Console.WriteLine("\n\tI. Wyznaczanie przyszłego stanu konta bankowego");
                Console.WriteLine("\n\tT. Tablicowanie wartości równania kwadratowego");
                //Console.WriteLine("\n\tO. Tablicowanie wartości funkcji w podanym przedziale");
                Console.WriteLine("\n\tX. Zakończenie (wyjście z) programu");

                Console.Write("\n\tNaciśnięciem klawisza wybierz odpowiednią funkcjonalnoscia programu");
                WybranaFunkcjalnosc = Console.ReadKey();
                if (WybranaFunkcjalnosc.Key == ConsoleKey.A)
                {
                    Console.WriteLine("\n\n\t\t\tObliczamy pierwiastki równania kwadratowego: \n");
                    double a, b, c;
                    double Delta;
                    double X1, X2, X1i2;
                    do
                    {
                        Console.Write("\tWprowadz wartość współczynnika a: ");
                        while (!double.TryParse(Console.ReadLine(), out a))
                        {
                            Console.WriteLine("\n\t ERROR: wystąpił niedozwolony znak w zapisie liczby");
                            Console.Write("\tPonownie wprowadż wartość współczynnika a : ");
                        }
                        if (a == 0.0f)
                        {
                            Console.WriteLine("\n\t ERROR: błąd w danych wejsciowych - współczynnik a nie może być równy zero");
                            Console.WriteLine("\n\t Nacśnij dowolny klawisz aby kontynuaowac program . . . ");
                            Console.ReadKey();
                        }
                    } while (a == 0.0f);

                    Console.Write("\tWporwadz wartość współczynnika b: ");
                    while (!double.TryParse(Console.ReadLine(), out b))
                    {
                        Console.WriteLine("\n\t ERROR: wystąpił niedozwolony znak w zapisie liczby");
                        Console.Write("\tWprowadz wartość współczynnika b ponownie: ");
                    }

                    Console.Write("\tWporwadz wartość współczynnika c: ");
                    while (!double.TryParse(Console.ReadLine(), out c))
                    {
                        Console.WriteLine("\n\t ERROR: wystąpil niedozwolony znak w zapisie liczby");
                        Console.Write("\tWprowadz wartość współczynnika c ponownie: ");
                    }
                    Delta = b * b - 4.0f * a * c;
                    if (Delta > 0)
                    {
                        X1 = (-b - (double)Math.Sqrt(Delta)) / (2 * a);
                        X2 = (-b + (double)Math.Sqrt(Delta)) / (2 * a);
                        Console.WriteLine("\n\t Równanie ma dwa perwiastki rzeczywiste: \n");
                        Console.WriteLine("\t X1 = {0, 8:G2} \t X2 = {1, 8:G2} \t Delta = {2, 8:G4}", X1, X2, Delta);
                    }
                    else
                        if (Delta < 0)
                        Console.WriteLine("\n\t Równanie nie ma pierwiastków rzeczywistych");
                    else
                    {
                        X1i2 = -b / (2.0f * 2);
                        Console.WriteLine("\n\t Równanie ma jeden pierwiastek podwójny:\n");
                        Console.Write("\t X1i2 = {0}", X1i2);
                        Console.WriteLine("\t Delta = {0}", Delta);
                        Console.WriteLine("\t Delta = {0, 9:E4}", Delta);
                    }
                    Console.ReadKey();
                }
                else
                    if (WybranaFunkcjalnosc.Key == ConsoleKey.B)
                {
                    Console.WriteLine("\n\n\t\t\tObliczamy wartość wielomianu n-tego stopnia: \n");
                    double X;
                    Console.Write("\n\tPodaj wartość zmiennej niezależnej X: ");
                    while (!double.TryParse(Console.ReadLine(), out X))
                    {
                        Console.WriteLine("\n\tERROR: Wystąpił niedozwolony znak w podanej wartości zmiennej niezależnej X! ");
                        Console.WriteLine("\n\tPodaj ponownie wartość zmiennej niezależnej X: ");
                    }
                    Console.WriteLine("\n\tWprowadzaj wartości współczynników w kolejności: an,a (n-1), a (a-2), ... a0, wprowadzanie współczynników" +
                        "kończymy naciśnieciem klawisza ENTER");

                    double WspolczynnikiWielomianu, Wx;
                    int LicznikWspolczynnikow;
                    string BuforKlawiatury;

                    Wx = 0.0F; LicznikWspolczynnikow = 0;
                    do
                    {
                        Console.WriteLine("\n\tPodaj wartość kolejnego współczynnika wielomianu: ");
                        BuforKlawiatury = Console.ReadLine();
                        if (BuforKlawiatury != "")
                        {
                            while (!double.TryParse(BuforKlawiatury, out WspolczynnikiWielomianu))
                            {
                                Console.WriteLine("\n\tERROR: w zapisie współczynnika wystąpił niedozwolony zank!");
                                Console.WriteLine("\n\tPodaj ponownie wartość współczynnika wielomianu: ");
                            }
                            Wx = Wx * X + WspolczynnikiWielomianu;
                            LicznikWspolczynnikow++;

                        }
                    } while (BuforKlawiatury != "");
                    Console.WriteLine("\n\n\tObliczona wartość wielomianu = {0, 6:F3} przy wczytanych {1}", Wx, LicznikWspolczynnikow);
                    Console.WriteLine("\n\tNacśnij dowolny klawisz aby kontynuaowac program . . .");

                    Console.ReadKey();
                }
                else
                    if (WybranaFunkcjalnosc.Key == ConsoleKey.C)
                {
                    Console.WriteLine("\n\n\t\t\tDokonujemy konwersji liczby naturalnej z zapisu dziesiętnego na zapis w systemie dwójkowym: \n");
                    short WczytanaLiczba;
                    Console.Write("\n\tPodaj liczbe naturalną (> 0) do konwersji: ");
                    while (!MojeTryParseLiczbaDziesietna(Console.ReadLine(), out WczytanaLiczba))
                    {
                        Console.WriteLine("\n\tERROR: Wystąpił niedozwolony znak!");
                        Console.WriteLine("\n\tWprowadz liczbę ponownie");
                        if (WczytanaLiczba <= 0)
                        {
                            Console.WriteLine("\n\tLiczba musi być większa od zera!");
                        }
                    }
                    byte SystemLiczbowyDlaWypisywanejLiczby = 2;
                    string ZnakowyZapisLiczby;
                    KonwersjaLiczbyNaSystemDwójkowy(WczytanaLiczba, SystemLiczbowyDlaWypisywanejLiczby, out ZnakowyZapisLiczby);

                    Console.WriteLine("\n\tWynniki: Liczba po konwersji: " + ZnakowyZapisLiczby + "(w systemie dwójkowym)");
                    Console.WriteLine("\n\tNacisnij dowolny klawisz dla kontynuacji działania programu . . .");
                    Console.ReadKey();
                }
                else
                    if (WybranaFunkcjalnosc.Key == ConsoleKey.D)
                {
                    Console.WriteLine("\n\tProgram oblicza cene jednostki paszy: \n");
                    int kmN;
                    double kmCenaPaszy;
                    double kmLicznik = 0; double kmMianownik = 0;
                    Console.WriteLine("\n\tWprowadz ilość składników paszy n: ");
                    while (!int.TryParse(Console.ReadLine(), out kmN))
                    {
                        Console.WriteLine("\n\tERROR: wystąpił niedozwolony znak!");
                        Console.WriteLine("\n\tWprowadż ilość składników ponownie");
                        if (kmN <= 0)
                        {
                            Console.WriteLine("\n\tERROR: n musi być większe od zera!");
                        }
                    }
                    double[] arrayC = new double[kmN];
                    double[] arrayM = new double[kmN];
                    for (int i = 0; i < kmN; i++)
                    {
                        Console.WriteLine("\n\tWprowadż cenę {0} - go skladnika: ", i + 1);
                        while (!double.TryParse(Console.ReadLine(), out arrayC[i]))
                        {
                            Console.WriteLine("\n\tERROR: Wystąpił niedozwolony znak!");
                            Console.WriteLine("\n\tWprowadż liczbę ponownie");
                            if (arrayC[i] <= 0)
                            {
                                Console.WriteLine("\n\tCena musi byc większa od zera!");
                            }
                        }
                        Console.WriteLine("\n\tWprowadż masę {0} - go składnika: ", i + 1);
                        while (!double.TryParse(Console.ReadLine(), out arrayM[i]))
                        {
                            Console.WriteLine("\n\tERROR: Wystąpił niedozwolony znak!");
                            Console.WriteLine("\n\tWprowadz liczbę ponownie");
                            if (arrayM[i] <= 0)
                            {
                                Console.WriteLine("\n\tMasa musi być większe od zera!");
                            }
                        }
                    }
                    Console.WriteLine("\n\tProgram liczy ceny jednostki paszy... \n");
                    for (int i = 0; i < kmN; i++)
                    {
                        kmLicznik += arrayM[i] * arrayC[i];
                        kmMianownik += arrayM[i];
                    }
                    kmCenaPaszy = kmLicznik / kmMianownik;
                    Console.WriteLine("\n\tCena jednostki paszy równa sie: " + kmCenaPaszy);
                    Console.ReadKey();
                }
                else
                    if (WybranaFunkcjalnosc.Key == ConsoleKey.E)
                {
                    Console.WriteLine("\n\tPorgram oblicza wartość średniej harmonicznej: \n");
                    int kmN;
                    double kmLicznik = 0; double kmMianownik = 0; double wynnik;
                    Console.WriteLine("\n\tWporwadz ilość n");
                    while (!int.TryParse(Console.ReadLine(), out kmN))
                    {
                        Console.WriteLine("\n\tERROR: wystąpił niedozwolony znak!");
                        Console.WriteLine("\n\tWprowadz ilość n ponownie");
                        if (kmN <= 0)
                        {
                            Console.WriteLine("\n\tERROR: n musi być większe od zera!");
                        }
                    }
                    double[] arrayA = new double[kmN];
                    for (int i = 0; i < kmN; i++)
                    {
                        while (arrayA[i] <= 0)
                        {
                            Console.WriteLine("\n\tWprowadz a - {0}", i + 1);
                            arrayA[i] = double.Parse(Console.ReadLine());
                            if (arrayA[i] <= 0)
                            {
                                Console.WriteLine("\n\tA musi być większe od zera!");
                            }

                        }
                    }
                    Console.WriteLine("\n\tProgram wyznacza średnią harmoniczną... \n");
                    for (int i = 0; i < kmN; i++)
                    {
                        kmLicznik = kmN;
                        kmMianownik += 1 / arrayA[i];
                    }
                    wynnik = kmLicznik / kmMianownik;
                    Console.WriteLine("\n\tWynnik równa się: " + wynnik);
                    Console.ReadLine();
                }
                else
                    if (WybranaFunkcjalnosc.Key == ConsoleKey.F)
                {
                    Console.WriteLine("\n\tProgram oblicza średnią geometryczną: ");
                    int kmN = 0;
                    double kmSredniaGeometryczna = 1; double kmIloczyn = 1;
                    Console.WriteLine("\n\tWprowadz illość n: ");
                    while (!int.TryParse(Console.ReadLine(), out kmN))
                    {
                        Console.WriteLine("\n\tERROR: Wystąpił niedozwolony znak!");
                        Console.WriteLine("\n\tWprowadz liczbę n ponownie");
                        if (kmN <= 0)
                        {
                            Console.WriteLine("\n\tN musi być większe od zera!");
                        }
                    }
                    double[] arrayA = new double[kmN];
                    for (int i = 0; i < kmN; i++)
                    {
                        Console.WriteLine("\n\tWprowadz a - {0}", i + 1);
                        while (!double.TryParse(Console.ReadLine(), out arrayA[i]))
                        {
                            Console.WriteLine("\n\tERROR: Wystąpił niedozwolony znak!");
                            Console.WriteLine("\n\tWprowadz liczbę ponownie");
                            if (arrayA[i] <= 0)
                            {
                                Console.WriteLine("\n\tA musi być większe od zera");
                            }
                        }
                    }
                    for (int i = 0; i < kmN; i++)
                    {
                        kmIloczyn *= arrayA[i];
                    }
                    kmSredniaGeometryczna = Math.Pow(kmIloczyn, 1.0 / kmN);
                    Console.WriteLine("\n\tŚrednia geometryczna równa się: " + kmSredniaGeometryczna);
                    Console.ReadKey();
                }
                else
                    if (WybranaFunkcjalnosc.Key == ConsoleKey.G)
                {
                    Console.WriteLine("\n\tProgram oblicza średnią kwadratową");
                    int kmN = 0;
                    double kmSredniaKwadratowa; double kmSumaLicznika = 0; double kmDzielienieUlamku;
                    Console.WriteLine("\n\tWprowadz ilość n: ");
                    while (!int.TryParse(Console.ReadLine(), out kmN))
                    {
                        Console.WriteLine("\n\tERROR: Wystąpił niedozwolony znak!");
                        Console.WriteLine("\n\tWprowadz liczbę ponownie");
                        if (kmN <= 0)
                        {
                            Console.WriteLine("\n\tn musi być większe od zera");
                        }
                    }
                    double[] arrayA = new double[kmN];
                    for (int i = 0; i < kmN; i++)
                    {
                        Console.WriteLine("\n\tWprowadz a - {0}", i + 1);
                        while (!double.TryParse(Console.ReadLine(), out arrayA[i]))
                        {
                            Console.WriteLine("\n\tERROR: Wystąpił niedozwolony znak!");
                            Console.WriteLine("\n\tWprowadz liczbę ponownie");
                            if (arrayA[i] <= 0)
                            {
                                Console.WriteLine("\n\ta musi być większe od zera");
                            }
                        }
                    }

                    for (int i = 0; i < kmN; i++)
                    {
                        kmSumaLicznika += (double)Math.Pow(arrayA[i], 2);
                    }
                    kmDzielienieUlamku = kmSumaLicznika / kmN;
                    kmSredniaKwadratowa = (double)Math.Sqrt(kmDzielienieUlamku);
                    Console.WriteLine("\n\tŚrednia kwadratowa równa siê: " + kmSredniaKwadratowa);
                    Console.ReadKey();
                }
                else
                    if (WybranaFunkcjalnosc.Key == ConsoleKey.H)
                {
                    Console.WriteLine("\n\tProgram oblicza średnią potęgową");
                    int kmN; int kmPower;
                    double kmSredniaPotęgowa; double kmSumaLicznika = 0; double kmDzielenieUlamka;
                    Console.WriteLine("\n\tWprowadz liczbę n:");
                    while (!int.TryParse(Console.ReadLine(), out kmN))
                    {
                        Console.WriteLine("\n\tERROR: Wystąpił niedozwolony znak!");
                        Console.WriteLine("\n\tWprowadz liczbę ponownie");
                        if (kmN <= 0)
                        {
                            Console.WriteLine("\n\tn musi być większe od zera!");
                        }
                    }
                    Console.WriteLine("\n\tWprowadz potęge: ");
                    while (!int.TryParse(Console.ReadLine(), out kmPower))
                    {
                        Console.WriteLine("\n\tERROR: Wystąpił niedozwolony znak!");
                        Console.WriteLine("\n\tWprowadz liczbe ponownie");
                        if (kmPower <= 0)
                        {
                            Console.WriteLine("\n\tPotęga musi być większe od zera!");
                        }
                    }
                    double[] arrayA = new double[kmN];
                    for (int i = 0; i < kmN; i++)
                    {
                        Console.WriteLine("\n\tWprowadz a - {0}", i + 1);
                        while (!double.TryParse(Console.ReadLine(), out arrayA[i]))
                        {
                            Console.WriteLine("\n\tERROR: Wystąpił niedozwolony znak!");
                            Console.WriteLine("\n\tWprowadz liczbę ponowmie");
                            if (arrayA[i] <= 0)
                            {
                                Console.WriteLine("\n\tPotęga musi być większe od zera!");
                            }
                        }
                    }
                    for (int i = 0; i < kmN; i++)
                    {
                        kmSumaLicznika += (double)Math.Pow(arrayA[i], kmPower);
                    }
                    kmDzielenieUlamka = kmSumaLicznika / kmN;
                    kmSredniaPotęgowa = Math.Pow(kmDzielenieUlamka, 1.0 / kmPower);
                    Console.WriteLine("\n\tŚrednia potęgowa równa się:" + kmSredniaPotęgowa);
                    Console.ReadKey();
                }
                else
                    if (WybranaFunkcjalnosc.Key == ConsoleKey.I)
                {
                    Console.WriteLine("\n\tProgram oblicza przyszły stan konta bankowego:");
                    double kmN;
                    Console.WriteLine("\n\tWprowadż illość lat lokaty:");
                    while (!double.TryParse(Console.ReadLine(), out kmN))
                    {

                        Console.WriteLine("\n\tERROR: Wystąpił niedozwolony znak!");
                        Console.WriteLine("\n\tWprowadz liczbę ponownie");
                        if (kmN <= 0)
                        {
                            Console.WriteLine("\n\tliczba musi być większa od zera!");

                        }
                    }
                }
                else
                    if (WybranaFunkcjalnosc.Key == ConsoleKey.T)
                {
                    double Xd, Xg, X, h, a, b, c;
                    Console.WriteLine("\n\tTablicowanie wartości równania kwadratowego ");
                    Console.Write("\n\tPodaj wartość współczynnika 'a': ");
                    a = double.Parse(Console.ReadLine());
                    Console.Write("\n\tPodaj wartość współczynnika 'b': ");
                    b = double.Parse(Console.ReadLine());
                    Console.Write("\n\tPodaj wartość współczynnika 'c': ");
                    c = double.Parse(Console.ReadLine());
                    Console.Write("\n\tPodaj dolną granię przedziału zmian wartoœci X, czyli Xd = ");
                    Xd = double.Parse(Console.ReadLine());
                    Console.Write("\n\tPodaj górną granicę przedziału zmian wartoœci X, czyli Xg = ");
                    Xg = double.Parse(Console.ReadLine());
                    Console.Write("\n\tPodaj przyrost (krok) zmian wartości X, czyli h = ");
                    h = double.Parse(Console.ReadLine());

                    Console.WriteLine("\n\t\t\t\tX\t\t\t  F(X)");
                    Console.WriteLine("\n\t\t\t__________\t\t\t__________");
                    X = Xd;
                    while (X <= Xg)
                    {
                        Console.Write("\n\t\t\t{0, 8:F2}\t\t\t{1, 8:E2} ", X, a * X * X + b * X + c);
                        X = X + h;

                    }
                    Console.WriteLine("\n\tNaciśnij dowolny klawisz dla kontynuacji działania programu. . . ");
                    Console.ReadKey();
                }
                /* if (WybranaFunkcjalnosc.Key == ConsoleKey.O)
                {
                    double Xd, Xg, X, a, b, c;
                    Console.WriteLine("\n\tTablicowanie wartości równania ");
                    Console.Write("\n\tPodaj dolną granię przedziału zmian wartoœci X, czyli Xd = ");
                    Xd = double.Parse(Console.ReadLine());
                    Console.Write("\n\tPodaj górną granicę przedziału zmian wartoœci X, czyli Xg = ");
                    Xg = double.Parse(Console.ReadLine());
                    Console.Write("\n\tPodaj wartosc X = ");
                    X = double.Parse(Console.ReadLine());

                    Console.WriteLine("\n\t\t\t\tX\t\t\t  F(X)");
                    Console.WriteLine("\n\t\t\t__________\t\t\t__________");
                    a = X * Math.Sin(X);
                    b = (Math.Asin(X) * Math.Acos(X)) / (1 + Math.Pow(X, 3));
                    c = Math.Log10(X) * Math.Cos(X) + Math.Pow(X, 6);
                    while (X < -1)
                    {

                        Console.Write("\n\t\t\t{0, 8:F2}\t\t\t{1, 8:E2} ", X, a * X * X + b * X + c);
                    }

                    while (-1 <= X)
                    {

                        Console.Write("\n\t\t\t{0, 8:F2}\t\t\t{1, 8:E2} ", X, a * X * X + b * X + c);
                    }

                    while (X > 1)
                    {

                        Console.Write("\n\t\t\t{0, 8:F2}\t\t\t{1, 8:E2} ", X, a * X * X + b * X + c);
                    }
                     Console.WriteLine("\n\tNaciśnij dowolny klawisz aby kontynuaowac prace programu. . . ");
                     Console.ReadKey(); */
                 else
                    if (WybranaFunkcjalnosc.Key == ConsoleKey.X)
                {
                    Console.WriteLine("\n\t ERROR: wybrałeś niedozwolony klawisz");
                    Console.WriteLine("\n\tDokonaj wyboru funkcjonalnoœci programu jeszcze raz");
                }
            } while (WybranaFunkcjalnosc.Key != ConsoleKey.X);
            Console.WriteLine("\n \tWyjscie z programu");
            Console.WriteLine("\n \t Autor: Kacper Małek, nr. albumu: 51214");
            Console.WriteLine("\n \tData i godzina uzyskania wynikow: {0}", DateTime.Now);
            Console.WriteLine("\n \tWcisnij klawisz aby wyjsc");
            Console.ReadKey();
        }
    }
}
