using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSMatchesManager.DAL.Entities;

namespace CSMatchesManager.DAL.Repositories
{
    public class RewardsRepos
    {
        private readonly AppDbContext db = new AppDbContext();


        public void ShowRewardWithId(int id)
        {
            var reward = db.Rewards.Find(id);
            if (reward == null) return;

            var player = db.Players.Find(reward.Player_id);
            var playerName = player.NickName;

            Console.WriteLine($"{player.NickName}: Majors: {reward.Majors} - Cologne: {reward.Cologne} - Katowice: {reward.Katowice} - ESL: {reward.ESL} - Grandslam: {reward.Grandslam} - HLTV Top 1: {reward.HLTV_TOP_1}");
            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }


        public void ShowAll()
        {
            var rewards = db.Rewards.ToList();

            foreach (var r in rewards)
            {
                ShowRewardWithId(r.Id);
            }
        }


        public void Add()
        {
            var plid = getint("Enter player id: ");
            var player = db.Players.Find(plid);
            if (player == null) return;

            db.Rewards.Add(new Rewards { Player_id = plid, Majors = getint("Enter Majors won: "), Cologne = getint("Enter Cologne won: "), Katowice = getint("Enter Katowice won: "), Grandslam = getint("Enter Grandslams Owned: "), ESL = getint("Enter ESL won: "), HLTV_TOP_1 = getint("Enter HLTV Top 1 Owned: ") });
            SaveChanges();
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }

        public void Remove(Rewards rewards)
        {
            if (rewards == null) return;
            db.Rewards.Remove(rewards);
            SaveChanges();
        }


        public void RemoveById(int id)
        {
            var rewards = db.Rewards.Find(id);
            Remove(rewards);
        }


        public void SaveChanges()
        {
            db.SaveChanges();
        }


        public Rewards GetRewardById(int id)
        {
            var rewards = db.Rewards.Find(id);
            if (rewards == null)
            {
                Console.WriteLine($"Reward with ID {id} not found.");
            }
            return rewards;
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
