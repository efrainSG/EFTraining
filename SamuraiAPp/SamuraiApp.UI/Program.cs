using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;

namespace SamuraiApp.UI
{
    internal class Program
    {
        private static SamuraiContext _context = new SamuraiContext();

        static void Main(string[] args)
        {
            //AddSamurais("Julie3", "Sampson3");
            AddVariousTypes();
            GetSamurais();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        static void AddSamurais(params string[] args)
        {
            foreach (string arg in args)
            {
                _context.Samurais.Add(new Domain.Samurai { Name = arg });
            }
            _context.SaveChanges();
        }

        private static void AddVariousTypes()
        {
            _context.Samurais.AddRange(
                new Samurai { Name = "Shimada" },
                new Samurai { Name = "Okamoto" }
                );
            _context.Battles.AddRange(
                new Battle { Name = "Battle of Anegawa" },
                new Battle { Name = "Battle of Nagashino" }
                );
            _context.SaveChanges();

            _context.AddRange(
                new Samurai { Name = "Shimada2" },
                new Samurai { Name = "Okamoto2" },
                new Battle { Name = "Battle of Anegawa 2" },
                new Battle { Name = "Battle of Nagashino 2" }
                );
            _context.SaveChanges();
        }

        static void GetSamurais()
        {
            var result = _context.Samurais;
            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
