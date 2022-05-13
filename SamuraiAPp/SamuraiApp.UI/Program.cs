using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SamuraiApp.UI
{
    public static class Program
    {
        private static SamuraiContext _context = new SamuraiContext();

        static void Main(string[] args)
        {
            //AddSamurais("Julie3", "Sampson3");
            //AddVariousTypes();

            //GetSamurais();
            //RetrieveAndUpdateSamurai();
            //RetrieveAndUpdateMultipleSamurais();
            //QueryAndUpdateBattles_Disconected();
            //InsertNewSamuraiWithQuote();
            //InsertNewSamuraiWithManyQuotes();
            //AddQuoteToExistingSamuraiWhileTracked();
            AddQuoteToExistingSamuraiNotTracked(1);
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
        private static void QueryAggregates()
        {
            var name = "Sampson";
            var samurais = _context.Samurais.Where(s => s.Name == name).ToList();
        }
        private static void RetrieveAndUpdateSamurai()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += " San";
            _context.SaveChanges();
        }
        private static void RetrieveAndUpdateMultipleSamurais()
        {
            var samurais = _context.Samurais.Skip(1).Take(4).ToList();
            samurais.ForEach(s => s.Name += " San");
            _context.SaveChanges();
        }
        private static void QueryAndUpdateBattles_Disconected()
        {
            List<Battle> disconnectedBattles;
            using (var context1 = new SamuraiContext())
            {
                disconnectedBattles = _context.Battles.ToList();
            }

            disconnectedBattles.ForEach(b =>
            {
                b.StartDate = new DateTime(1570, 01, 01);
                b.FinishDate = new DateTime(1570, 12, 01);
            });
            using (var context2 = new SamuraiContext())
            {
                context2.UpdateRange(disconnectedBattles);
                context2.SaveChanges();
            }
        }
        private static void InsertNewSamuraiWithQuote()
        {
            var samurai = new Samurai
            {
                Name = "Kambei Shimada",
                Quotes = new List<Quote>
                {
                    new Quote { Text = "I've come to save you." }
                }
            };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }
        private static void InsertNewSamuraiWithManyQuotes()
        {
            var samurai = new Samurai
            {
                Name = "Kyûzò",
                Quotes = new List<Quote>
                {
                    new Quote { Text = "Watch out for my sharp sword!" },
                    new Quote { Text = "I told you to watch out for the sharp sword! Oh well!" }
                }
            };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }

        private static void AddQuoteToExistingSamuraiWhileTracked()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Quotes.Add(new Quote
            {
                Text = "I bet you're happy that I've saved you!"
            });
            _context.SaveChanges();
        }

        private static void AddQuoteToExistingSamuraiNotTracked(int id)
        {
            var samurai = _context.Samurais.Find(id);
            samurai.Quotes.Add(new Quote
            {
                Text = "Now that I saved you, will you feed me dinner?"
            });
            using (var context2 = new SamuraiContext())
            {
                context2.Samurais.Update(samurai);
                context2.SaveChanges();
            }
        }
    }
}
