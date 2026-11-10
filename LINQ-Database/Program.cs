namespace LINQ_Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            List<Diak> diakok = database.DiakokBetoltese();

            var eredmeny_1 = diakok
                .GroupBy(MySqlX => MySqlX.Osztaly)
                .Select(csoport => new
                {
                    Osztaly = csoport.Key,
                    Atlag = csoport.Average(MySqlX => MySqlX.Atlag)
                });

            foreach (var MySqlX in eredmeny_1)
            {
                Console.WriteLine($"Az {MySqlX.Osztaly} osztály átlaga: {MySqlX.Atlag:F2}");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Gray;

            var eredmeny_2 = diakok
                .GroupBy(MySqlX => MySqlX.Osztaly)
                .Select(csoport => new
                {
                    Osztaly = csoport.Key,
                    Atlag = csoport.Average(MySqlX => MySqlX.Atlag)
                })
                .OrderByDescending(MySqlX => MySqlX.Atlag);

            foreach (var MySqlX in eredmeny_2)
            {
                Console.WriteLine($"Az {MySqlX.Osztaly} osztály átlaga: {MySqlX.Atlag:F2}");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Gray;

            var eredmeny_3 = diakok
                .GroupBy(MySqlX => MySqlX.Osztaly)
                .Select(csoport => 
                {
                    double legjobb = csoport.Max(MySqlX => MySqlX.Atlag);

                    return csoport
                        .Where(MySqlX => MySqlX.Atlag == legjobb)
                        .Select(MySqlX => new
                        {
                            Osztaly = csoport.Key,
                            MySqlX.Nev,
                            MySqlX.Atlag
                        });
                });

            foreach (var MySqlX in eredmeny_3)
            {
                foreach (var item in MySqlX)
                {
                    Console.WriteLine($"Az {item.Osztaly} osztály legjobb tanulója: {item.Nev}: {item.Atlag}");
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Gray;

            var eredmeny_4 = diakok
                .GroupBy(MySqlX => MySqlX.Eletkor)
                .Select(csoport => new
                {
                    Eletkor = csoport.Key,
                    Letszam = csoport.Count()
                });

            foreach (var MySqlX in eredmeny_4)
            {
                Console.WriteLine($"Az {MySqlX.Eletkor} osztály létszáma: {MySqlX.Letszam}");
            }
        }
    }
}
