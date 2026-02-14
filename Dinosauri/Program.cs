using System;

enum TipoDinosauro { Brontosauro, Triceratopo, Pterodattilo, TRex, Stegosauro }

enum Taglia { Piccolo, Medio, Grande }

struct Dinosauro
{
    public int codice;
    public TipoDinosauro tipo;
    public Taglia taglia;
    public int eta;
    public int forza;
    public string proprietario;

    public Dinosauro(int cod, TipoDinosauro t, Taglia tag, int e, int f, string prop)
    {
        codice = cod;
        tipo = t;
        taglia = tag;
        eta = e;
        forza = f;
        proprietario = prop;
    }

    public string Stampa()
    {
        return $"Codice: {codice} | Tipo: {tipo} | Taglia: {taglia} | Età: {eta} anni | Forza: {forza} | Proprietario: {proprietario}";
    }
}

class Program
{
    static void Main()
    {
        Dinosauro[] recinto = new Dinosauro[20];
        int numeroDinosauri = 0;
        string scelta = "";
        bool continua = true;

        while (continua)
        {
            Console.WriteLine("\n MERCATO DINOSAURI DI BEDROCK ");
            Console.WriteLine();
            Console.WriteLine("1. Riempi il recinto");
            Console.WriteLine("2. Sostituisci dinosauro");
            Console.WriteLine("3. Scambia proprietari");
            Console.WriteLine("4. Visualizza tutti");
            Console.WriteLine("5. Filtra per tipo");
            Console.WriteLine("6. Filtra per taglia");
            Console.WriteLine("7. Esci");
            Console.Write("\nScelta: ");
            scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    RiempiRecinto(recinto, ref numeroDinosauri);
                    break;
                case "2":
                    SostituisciDinosauro(recinto, numeroDinosauri);
                    break;
                case "3":
                    ScambiaProprietari(recinto, numeroDinosauri);
                    break;
                case "4":
                    VisualizzaTutti(recinto, numeroDinosauri);
                    break;
                case "5":
                    FiltraPerTipo(recinto, numeroDinosauri);
                    break;
                case "6":
                    FiltraPerTaglia(recinto, numeroDinosauri);
                    break;
                case "7":
                    Console.WriteLine("\nGrazie per aver usato il mercato di Bedrock");
                    continua = false;
                    break;
                default:
                    Console.WriteLine("\nScelta non valida.");
                    break;
            }
        }
    }

    static string LeggiProprietario()
    {
        string proprietario;
        do
        {
            Console.Write("Proprietario: ");
            proprietario = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(proprietario))
            {
                continue;
            }

            int numero;
            if (int.TryParse(proprietario, out numero))
            {
                Console.WriteLine("Errore: il proprietario non può essere un numero.");
                proprietario = "";
            }

        } while (string.IsNullOrWhiteSpace(proprietario));

        return proprietario;
    }

    static void RiempiRecinto(Dinosauro[] recinto, ref int numeroDinosauri)
    {
        Console.WriteLine("\n RIEMPI IL RECINTO ");
        Console.WriteLine();

        int quantita;
        do
        {
            Console.Write("Quanti dinosauri vuoi inserire (max 20): ");
        } while (!int.TryParse(Console.ReadLine(), out quantita) || quantita <= 0 || quantita > 20);

        numeroDinosauri = quantita;

        for (int i = 0; i < quantita; i++)
        {
            Console.WriteLine();
            Console.WriteLine("Dinosauro " + (i + 1));

            int codice;
            do
            {
                Console.Write("Codice: ");
            } while (!int.TryParse(Console.ReadLine(), out codice) || codice <= 0);

            int tipoScelto;
            do
            {
                Console.WriteLine("Tipo (0=Brontosauro, 1=Triceratopo, 2=Pterodattilo, 3=TRex, 4=Stegosauro): ");
                Console.Write("Scelta: ");
            } while (!int.TryParse(Console.ReadLine(), out tipoScelto) || tipoScelto < 0 || tipoScelto > 4);

            int tagliascelta;
            do
            {
                Console.WriteLine("Taglia (0=Piccolo, 1=Medio, 2=Grande): ");
                Console.Write("Scelta: ");
            } while (!int.TryParse(Console.ReadLine(), out tagliascelta) || tagliascelta < 0 || tagliascelta > 2);

            int eta;
            do
            {
                Console.Write("Età (anni): ");
            } while (!int.TryParse(Console.ReadLine(), out eta) || eta < 0);

            int forza;
            do
            {
                Console.Write("Forza (1-100): ");
            } while (!int.TryParse(Console.ReadLine(), out forza) || forza < 1 || forza > 100);

            string proprietario = LeggiProprietario();

            recinto[i] = new Dinosauro(codice, (TipoDinosauro)tipoScelto, (Taglia)tagliascelta, eta, forza, proprietario);
        }

        Console.WriteLine("\nRecinto riempito con successo");
    }

    static void SostituisciDinosauro(Dinosauro[] recinto, int numeroDinosauri)
    {
        if (numeroDinosauri == 0)
        {
            Console.WriteLine("\nIl recinto è vuoto.");
            return;
        }

        Console.WriteLine("\n SOSTITUISCI DINOSAURO ");
        Console.WriteLine();

        int codice;
        do
        {
            Console.Write("Inserisci il codice del dinosauro da sostituire: ");
        } while (!int.TryParse(Console.ReadLine(), out codice));

        bool trovato = false;
        int posizione = 0;

        for (int i = 0; i < numeroDinosauri; i++)
        {
            if (recinto[i].codice == codice)
            {
                trovato = true;
                posizione = i;
                break;
            }
        }

        if (trovato == false)
        {
            Console.WriteLine("\nDinosauro non trovato.");
            return;
        }

        Console.WriteLine("\nDinosauro trovato: " + recinto[posizione].Stampa());
        Console.WriteLine();
        Console.WriteLine("Inserisci i dati del nuovo dinosauro:");

        int nuovoCodice;
        do
        {
            Console.Write("Codice: ");
        } while (!int.TryParse(Console.ReadLine(), out nuovoCodice) || nuovoCodice <= 0);

        int tipoScelto;
        do
        {
            Console.WriteLine("Tipo (0=Brontosauro, 1=Triceratopo, 2=Pterodattilo, 3=TRex, 4=Stegosauro): ");
            Console.Write("Scelta: ");
        } while (!int.TryParse(Console.ReadLine(), out tipoScelto) || tipoScelto < 0 || tipoScelto > 4);

        int tagliascelta;
        do
        {
            Console.WriteLine("Taglia (0=Piccolo, 1=Medio, 2=Grande): ");
            Console.Write("Scelta: ");
        } while (!int.TryParse(Console.ReadLine(), out tagliascelta) || tagliascelta < 0 || tagliascelta > 2);

        int eta;
        do
        {
            Console.Write("Età (anni): ");
        } while (!int.TryParse(Console.ReadLine(), out eta) || eta < 0);

        int forza;
        do
        {
            Console.Write("Forza (1-100): ");
        } while (!int.TryParse(Console.ReadLine(), out forza) || forza < 1 || forza > 100);

        string proprietario = LeggiProprietario();

        recinto[posizione] = new Dinosauro(nuovoCodice, (TipoDinosauro)tipoScelto, (Taglia)tagliascelta, eta, forza, proprietario);

        Console.WriteLine("\nDinosauro sostituito con successo");
    }

    static void ScambiaProprietari(Dinosauro[] recinto, int numeroDinosauri)
    {
        if (numeroDinosauri < 2)
        {
            Console.WriteLine("\nServono almeno 2 dinosauri per scambiare i proprietari.");
            return;
        }

        Console.WriteLine("\n SCAMBIA PROPRIETARI ");
        Console.WriteLine();

        int codice1;
        do
        {
            Console.Write("Inserisci il primo codice: ");
        } while (!int.TryParse(Console.ReadLine(), out codice1));

        int codice2;
        do
        {
            Console.Write("Inserisci il secondo codice: ");
        } while (!int.TryParse(Console.ReadLine(), out codice2));

        bool trovato1 = false;
        bool trovato2 = false;
        int posizione1 = 0;
        int posizione2 = 0;

        for (int i = 0; i < numeroDinosauri; i++)
        {
            if (recinto[i].codice == codice1)
            {
                trovato1 = true;
                posizione1 = i;
            }
            if (recinto[i].codice == codice2)
            {
                trovato2 = true;
                posizione2 = i;
            }
        }

        if (trovato1 == false || trovato2 == false)
        {
            Console.WriteLine("\nUno o entrambi i dinosauri non sono stati trovati.");
            return;
        }

        string temp = recinto[posizione1].proprietario;
        Dinosauro dino1 = recinto[posizione1];
        dino1.proprietario = recinto[posizione2].proprietario;
        recinto[posizione1] = dino1;

        Dinosauro dino2 = recinto[posizione2];
        dino2.proprietario = temp;
        recinto[posizione2] = dino2;

        Console.WriteLine("\nProprietari scambiati con successo");
    }

    static void VisualizzaTutti(Dinosauro[] recinto, int numeroDinosauri)
    {
        Console.WriteLine("\n ELENCO DINOSAURI NEL RECINTO ");
        Console.WriteLine();

        if (numeroDinosauri == 0)
        {
            Console.WriteLine("Nessun dinosauro presente.");
        }
        else
        {
            for (int i = 0; i < numeroDinosauri; i++)
            {
                Console.WriteLine(recinto[i].Stampa());
            }
        }
    }

    static void FiltraPerTipo(Dinosauro[] recinto, int numeroDinosauri)
    {
        if (numeroDinosauri == 0)
        {
            Console.WriteLine("\nIl recinto è vuoto.");
            return;
        }

        Console.WriteLine("\n FILTRA PER TIPO ");
        Console.WriteLine();

        int tipoScelto;
        do
        {
            Console.WriteLine("Tipo (0=Brontosauro, 1=Triceratopo, 2=Pterodattilo, 3=TRex, 4=Stegosauro): ");
            Console.Write("Scelta: ");
        } while (!int.TryParse(Console.ReadLine(), out tipoScelto) || tipoScelto < 0 || tipoScelto > 4);

        TipoDinosauro tipoFiltro = (TipoDinosauro)tipoScelto;
        bool trovato = false;

        Console.WriteLine();
        Console.WriteLine("Dinosauri di tipo " + tipoFiltro + ":");
        Console.WriteLine();

        for (int i = 0; i < numeroDinosauri; i++)
        {
            if (recinto[i].tipo == tipoFiltro)
            {
                Console.WriteLine(recinto[i].Stampa());
                trovato = true;
            }
        }

        if (trovato == false)
        {
            Console.WriteLine("Nessun dinosauro di questo tipo.");
        }
    }

    static void FiltraPerTaglia(Dinosauro[] recinto, int numeroDinosauri)
    {
        if (numeroDinosauri == 0)
        {
            Console.WriteLine("\nIl recinto è vuoto.");
            return;
        }

        Console.WriteLine("\n FILTRA PER TAGLIA ");
        Console.WriteLine();

        int tagliaScelta;
        do
        {
            Console.WriteLine("Taglia (0=Piccolo, 1=Medio, 2=Grande): ");
            Console.Write("Scelta: ");
        } while (!int.TryParse(Console.ReadLine(), out tagliaScelta) || tagliaScelta < 0 || tagliaScelta > 2);

        Taglia tagliaFiltro = (Taglia)tagliaScelta;
        bool trovato = false;

        Console.WriteLine();
        Console.WriteLine("Dinosauri di taglia " + tagliaFiltro + ":");
        Console.WriteLine();

        for (int i = 0; i < numeroDinosauri; i++)
        {
            if (recinto[i].taglia == tagliaFiltro)
            {
                Console.WriteLine(recinto[i].Stampa());
                trovato = true;
            }
        }

        if (trovato == false)
        {
            Console.WriteLine("Nessun dinosauro di questa taglia.");
        }
    }
}