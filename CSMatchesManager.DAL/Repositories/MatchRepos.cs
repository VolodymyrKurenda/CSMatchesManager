using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSMatchesManager.DAL.Entities;

namespace CSMatchesManager.DAL.Repositories
{
    public class MatchRepos
    {
        private readonly AppDbContext db = new AppDbContext();


        public void ShowMatchWithId(int id)
        {
            var match = db.Matches.Find(id);
            if (match == null) return;

            var Teammatch = db.Teams_Matches.FirstOrDefault(tm => tm.MatchID == id);
            if (Teammatch == null) return;

            var team1name = Teammatch.Team1.Name;

            var team2name = Teammatch.Team2.Name;


            Console.WriteLine($"{match.Tournament_Name} -- {match.Date.ToString()}: {team1name} {match.team1_Rounds} - {match.team2_Rounds} {team2name}");
            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();

        }


        public void ShowAll()
        {
            var match = db.Matches.ToList();

            foreach (var m in match)
            {
                ShowMatchWithId(m.id);
            }
            
        }


        public void SaveChanges()
        {
            db.SaveChanges();
        }


        public void Add()
        {
            int team1id = getint("Enter team 1 id: ");
            int team2id = getint("Enter team 2 id: ");

            var team1 = db.Teams.Find(team1id);
            var team2 = db.Teams.Find(team2id);
            if (team1 == null || team2 == null) return;

            var match = new Matches { team1_Rounds = getint($"{team1.Name} rounds: "), team2_Rounds = getint($"{team2.Name} rounds: "), Date = GetDateOnly("Enter match date YYYY-MM-DD: "), Tournament_Name = getstring("Enter tournament name: ") };
            db.Matches.Add(match);
            db.SaveChanges();
            db.Teams_Matches.Add(new Teams_Match { Team1_id = team1id, Team2_id = team2id, MatchID = match.id });
            SaveChanges();
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }


        public Matches GetMatchById(int id)
        {
            var match = db.Matches.Find(id);
            if (match == null)
            {
                Console.WriteLine($"Match with ID {id} not found.");
            }
            return match;
        }


        public void Remove(Matches match)
        {
            if (match == null) return;

            var tm = db.Teams_Matches.FirstOrDefault(tm => tm.MatchID == match.id);
            if (tm != null) db.Teams_Matches.Remove(tm);
            db.Matches.Remove(match);
            SaveChanges();

        }

        public void RemoveById(int id)
        {
            var match = db.Matches.Find(id);
            Remove(match);
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

        public DateOnly GetDateOnly(string message)
        {
            int tries = 0;
            Console.Write(message);
            while (tries < 3)
            {

                if (DateOnly.TryParse(Console.ReadLine(), out DateOnly result))
                {
                    return result;
                }

                tries++;
                Console.WriteLine($"Invalid input, please enter a Date YYYY-MM-DD (Attempt {tries}/3)");
            }
            return default;
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

