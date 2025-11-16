using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using CSMatchesManager.DAL.Entities;

namespace CSMatchesManager.DAL.Repositories
{
    public class PlayerRepos
    {
        private readonly AppDbContext db = new AppDbContext();


        public void ShowPlayerWithId(int id)
        {
            var player = db.Players.Find(id);
            if (player == null) return;


            Console.WriteLine($"FullName: {player.FullName} - nick: {player.NickName} - Rating: {player.Rating} - KD: {player.KD} - Firepower: {player.Firepower} - Sniping: {player.Sniping} - Gamerole: {player.GameRole} ");
            Console.WriteLine("=========================================================================================================");

            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }


        public void ShowAll()
        {
            var player = db.Players.ToList();

            foreach (var p in player)
            {
                ShowPlayerWithId(p.Id);
            }
        }

        public void Add()
        {
            var teamid = getint("Enter team id: ");
            
            var team = db.Teams.Find(teamid);
            if (team == null) return;

            db.Players.Add(new Players { FullName = getstring("Enter FullName: "), NickName = getstring("Enter Nickname: "), Rating = getfloat("Enter Rating: "), KD = getfloat("Enter KD: "), Firepower = getint("Enter Firepower: "), Sniping = getint("Enter Sniping: "), GameRole = getstring("Enter Gamerole: "), Team_id = teamid });

            SaveChanges();

            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }


        public void Remove(Players player)
        {
            if (player == null) return;
            db.Players.Remove(player);
            SaveChanges();
        }


        public void RemoveById(int id)
        {
            var player = db.Players.Find(id);
            Remove(player);
        }


        public void SaveChanges()
        {
            db.SaveChanges();
        }


        public Players GetPlayerById(int id)
        {
            var player = db.Players.Find(id);
            if (player == null)
            {
                Console.WriteLine($"Player with ID {id} not found.");
            }
            return player;
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
