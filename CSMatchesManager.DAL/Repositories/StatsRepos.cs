using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSMatchesManager.DAL.Entities;

namespace CSMatchesManager.DAL.Repositories
{
    public class StatsRepos
    {
        private readonly AppDbContext db = new AppDbContext();


        public void ShowStatisticWithId(int id)
        {
            var stat = db.Statistics.Find(id);
            if (stat == null) return;

            Console.WriteLine($"Kills: {stat.Kills} - Deaths: {stat.Deaths} - Assists: {stat.Assists} - HSRate: {stat.HSRate} - Avg Damage: {stat.AVGDamage} ");
            Console.WriteLine("=========================================================================================================");

            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }


        public void ShowAll()
        {
            var stats = db.Statistics.ToList();

            foreach (var s in stats)
            {
                ShowStatisticWithId(s.Id);
            }
        }


        public void Remove(Statistic statistic)
        {
            if (statistic == null) return;
            db.Statistics.Remove(statistic);
            SaveChanges();

        }


        public void RemoveById(int id)
        {
            var statistic = db.Statistics.Find(id);
            Remove(statistic);
        }


        public Statistic GetStatById(int id)
        {
      
            var statistic = db.Statistics.Find(id);
            if (statistic == null)
            {
                Console.WriteLine($"Statistic with ID {id} not found.");
            }
            return statistic;
        }


        public void SaveChanges()
        {
            db.SaveChanges();
        }


        public void Add()
        {
            int plid = getint("Enter player id: ");
            int maid = getint("Enter match id: ");

            var player = db.Players.Find(plid);
            var match = db.Matches.Find(maid);
            if (player == null || match == null) return;

            db.Statistics.Add(new Statistic {Kills = getint("Enter Kills: "),Deaths = getint("Enter Deaths: "),Assists = getint("Enter Assists: "),HSRate = getint("Enter HSRate: "),AVGDamage = getfloat("Enter AVG Damage: "),Match_id = maid, Player_id = plid });
            SaveChanges();

            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }


        public string getstring(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }


        public int getint(string message)
        {
            int tries = 0;
            while (tries < 3)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return result;
                }

                tries++;
                Console.WriteLine($"Invalid input, please enter a number! (Attempt {tries}/3)");
            }
            return -1;
        }


        public float getfloat(string message)
        {
            int tries = 0;
            while (tries < 3)
            {
                Console.Write(message);
                if (float.TryParse(Console.ReadLine(), out float result))
                {
                    return result;
                }

                tries++;
                Console.WriteLine($"Invalid input, please enter a number! (Attempt {tries}/3)");
            }
            return -1;
        }
    }
}
