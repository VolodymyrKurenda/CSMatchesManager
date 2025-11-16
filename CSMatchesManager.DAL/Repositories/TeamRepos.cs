using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSMatchesManager.DAL.Entities;

namespace CSMatchesManager.DAL.Repositories
{
    public class TeamRepos
    {
        private readonly AppDbContext db = new AppDbContext();


        public void ShowTeamWithId(int id)
        {
            var team = db.Teams.Find(id);
            if (team == null) return;

            Console.WriteLine($"{team.Name} - foundingdate: {team.Foundingdate.ToString()} - majors: {team.MajorWon}");
            Console.WriteLine("=========================================================================================================");

            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }


        public void ShowAll()
        {
            var teams = db.Teams.ToList();

            foreach (var t in teams)
            {
                ShowTeamWithId(t.Id);
            }
        }


        public Teams GetTeamById(int id)
        {
            var team = db.Teams.Find(id);
            if (team == null)
            {
                Console.WriteLine($"Team with ID {id} not found.");
            }
            return team;
        }
        public void Add()
        {
            db.Teams.Add(new Teams { Name = getstring("Enter team name: "), MajorWon = getint("Enter how much majors team has: "), Foundingdate = GetDateOnly("Enter founding date YYYY-MM-DD: ") });
            SaveChanges();

            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }


        public void Remove(Teams team)
        {
            if (team == null) return;

            var Players = db.Players.Where(p => p.Team_id == team.Id).ToList();
            if (Players.Any()) db.Players.RemoveRange(Players);

            db.Teams.Remove(team);
            SaveChanges();

        }

        public void RemoveById(int id)
        {
            var team = db.Teams.Find(id);
            Remove(team);
        }


        public void SaveChanges() => db.SaveChanges();



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

                tries++;Console.WriteLine($"Invalid input, please enter a Date YYYY-MM-DD (Attempt {tries}/3)");
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

