using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSMatchesManager.DAL.Entities;
using CSMatchesManager.DAL.Repositories;

namespace CSMatchesManager
{
    public class Menu
    {
        TeamRepos tr = new TeamRepos();

        MatchRepos mr = new MatchRepos();

        StatsRepos sr = new StatsRepos();

        PlayerRepos pr = new PlayerRepos();

        RewardsRepos rr = new RewardsRepos();

        public void Main_Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Main Menu===");
                Console.WriteLine("1 - Team Menu");
                Console.WriteLine("2 - Players Menu");
                Console.WriteLine("3 - Matches Menu");
                Console.WriteLine("4 - Statistic Menu");
                Console.WriteLine("5 - Rewards Menu");
                Console.WriteLine("0 - Exit");
                switch (getint("Your choice: "))
                {
                    case 0:
                        Console.WriteLine("Exting...");
                        return;
                    case 1:
                        Team_Menu();
                        break;
                    case 2:
                        Players_Menu();
                        break;
                    case 3:
                        Matches_Menu();
                        break;
                    case 4:
                        Statistic_Menu();
                        break;
                    case 5:
                        Rewards_Menu();
                        break;
                    default:
                        Console.WriteLine("Enter a number from 0 to ");
                        break;
                }
            }    
        }


        public void Rewards_Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Rewards Menu===");
                Console.WriteLine("1 - Add Reward");
                Console.WriteLine("2 - Update Reward");
                Console.WriteLine("3 - Remove Reward");
                Console.WriteLine("4 - Show Reward");
                Console.WriteLine("5 - Show All Rewards");
                Console.WriteLine("0 - Back to Main Menu");
                switch (getint("Your choice: "))
                {
                    case 0:
                        Console.WriteLine("Back to Main Menu...");
                        return;
                    case 1:
                        rr.Add();
                        break;
                    case 2:
                        RewardsUpdateMenu();
                        break;
                    case 3:
                        rr.RemoveById(getint("Enter removable reward id: "));
                        break;
                    case 4:
                        rr.ShowRewardWithId(getint("Enter statistic id: "));
                        break;
                    case 5:
                        rr.ShowAll();
                        break;
                    default:
                        Console.WriteLine("Enter a number from 0 to 3");
                        break;
                }
            }
        }


        public void RewardsUpdateMenu()
        {
            var reward = rr.GetRewardById(getint("Enter reward id: "));
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Reward Update Menu ===");
                Console.WriteLine("1 - Update Majors won");
                Console.WriteLine("2 - Update Cologne won");
                Console.WriteLine("3 - Update Katowice won");
                Console.WriteLine("4 - Update Grandslam owned");
                Console.WriteLine("5 - Update ESL won");
                Console.WriteLine("6 - Update HLTV Top 1 owned");
                Console.WriteLine("0 - Back to Rewards Menu");
                switch (getint("Your choice: "))
                {
                    case 0:
                        rr.SaveChanges();
                        Console.WriteLine("Back to Rewards Menu...");
                        return;
                    case 1:
                        reward.Majors = getint("Enter Majors won: ");
                        break;
                    case 2:
                        reward.Cologne = getint("Enter Cologne won: ");
                        break;
                    case 3:
                        reward.Katowice = getint("Enter Katowice won: ");
                        break;
                    case 4:
                        reward.Grandslam = getint("Enter Grandslam owned: ");
                        break;
                    case 5:
                        reward.ESL = getint("Enter ESL won: ");
                        break;
                    case 6:
                        reward.HLTV_TOP_1 = getint("Enter HLTV Top 1 owned: ");
                        break;
                    default:
                        Console.WriteLine("Enter from 0 to 6");
                        break;
                }
            }
        }

        public void Players_Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Player Menu===");
                Console.WriteLine("1 - Add Player");
                Console.WriteLine("2 - Update Player");
                Console.WriteLine("3 - Remove Player");
                Console.WriteLine("4 - Show Player");
                Console.WriteLine("5 - Show All Player");
                Console.WriteLine("0 - Back to Main Menu");
                switch (getint("Your choice: "))
                {
                    case 0:
                        Console.WriteLine("Back to Main Menu...");
                        return;
                    case 1:
                        pr.Add();
                        break;
                    case 2:
                        PlayerUpdateMenu();
                        break;
                    case 3:
                        pr.RemoveById(getint("Enter removable player id: "));
                        break;
                    case 4:
                        pr.ShowPlayerWithId(getint("Enter Player id"));
                        break;
                    case 5:
                        pr.ShowAll();
                        break;
                    default:
                        Console.WriteLine("Enter a number from 0 to 3");
                        break;
                }
            }
        }


        public void PlayerUpdateMenu()
        {
            var player = pr.GetPlayerById(getint("Enter player id: "));
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Player Update Menu ===");
                Console.WriteLine("1 - Update Fullname");
                Console.WriteLine("2 - Update Nickname");
                Console.WriteLine("3 - Update Rating");
                Console.WriteLine("4 - Update KD");
                Console.WriteLine("5 - Update Firepower");
                Console.WriteLine("6 - Update Sniping");
                Console.WriteLine("7 - Update Gamerole");
                Console.WriteLine("0 - Back to Player Menu");
                switch (getint("Your choice: "))
                {
                    case 0:
                        pr.SaveChanges();
                        Console.WriteLine("Back to Player Menu...");
                        return;
                    case 1:
                        player.FullName = getstring("Enter FullName: ");
                        break;
                    case 2:
                        player.NickName = getstring("Enter Nickname: ");
                        break;
                    case 3:
                        player.Rating = getfloat("Enter Rating: ");
                        break;
                    case 4:
                        player.KD = getfloat("Enter KD: ");
                        break;
                    case 5:
                        player.Firepower = getint("Enter Firepower: ");
                        break;
                    case 6:
                        player.Sniping = getint("Enter Sniping: ");
                        break;
                    case 7:
                        player.GameRole = getstring("Enter Gamerole: ");
                        break;
                    default:
                        Console.WriteLine("Enter from 0 to 7");
                        break;
                }
            }
        }


        public void Statistic_Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Statistic Menu===");
                Console.WriteLine("1 - Add Statistic");
                Console.WriteLine("2 - Update Statistic");
                Console.WriteLine("3 - Remove Statistic");
                Console.WriteLine("4 - Show Statistic");
                Console.WriteLine("5 - Show All Statistics");
                Console.WriteLine("0 - Back to Main Menu");
                switch (getint("Your choice: "))
                {
                    case 0:
                        Console.WriteLine("Back to Main Menu...");
                        return;
                    case 1:
                        sr.Add();
                        break;
                    case 2:
                        StatisticUpdateMenu();
                        break;
                    case 3:
                        sr.RemoveById(getint("Enter removable statistic id: "));
                        break;
                    case 4:
                        sr.ShowStatisticWithId(getint("Enter statistic id: "));
                        break;
                    case 5:
                        sr.ShowAll();
                        break;
                    default:
                        Console.WriteLine("Enter a number from 0 to 3");
                        break;
                }
            }
        }


        public void StatisticUpdateMenu()
        {
            var statistic = sr.GetStatById(getint("Enter Statistic id: "));
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Statistic Update Menu ===");
                Console.WriteLine("1 - Update Kills");
                Console.WriteLine("2 - Update Deaths");
                Console.WriteLine("3 - Update Assists");
                Console.WriteLine("4 - Update HSRate");
                Console.WriteLine("5 - Update AVGDamage");
                Console.WriteLine("0 - Back to Statistic Menu");
                switch (getint("Your choice: "))
                {
                    case 0:
                        sr.SaveChanges();
                        Console.WriteLine("Back to Statistic Menu...");
                        return;
                    case 1:
                        statistic.Kills = getint("Enter Kills: ");
                        break;
                    case 2:
                        statistic.Deaths = getint("Enter Deaths: ");
                        break;
                    case 3:
                        statistic.Assists = getint("Enter Assists: ");
                        break;
                    case 4:
                        statistic.HSRate = getint("Enter HSRate: ");
                        break;
                    case 5:
                        statistic.AVGDamage = getfloat("Enter AVG Damage: ");
                        break;
                    default:
                        Console.WriteLine("Enter from 0 to 5");
                        break;
                }
            }
        }


        public void Matches_Menu()
        {
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Matches Menu===");
                Console.WriteLine("1 - Add Match");
                Console.WriteLine("2 - Update Match");
                Console.WriteLine("3 - Remove Match");
                Console.WriteLine("4 - Show Match");
                Console.WriteLine("5 - Show All Matches");
                Console.WriteLine("0 - Back to Main Menu");
                switch (getint("Your choice: "))
                {
                    case 0:
                        Console.WriteLine("Back to Main Menu...");
                        return;
                    case 1:
                        mr.Add();
                        break;
                    case 2:
                        MatchUpdateMenu();
                        break;
                    case 3:
                        mr.RemoveById(getint("Enter removable match id: "));
                        break;
                    case 4:
                        mr.ShowMatchWithId(getint("Enter match id: "));
                        break;
                    case 5:
                        mr.ShowAll();
                        break;
                    default:
                        Console.WriteLine("Enter a number from 0 to 3");
                        break;
                }
            }
        }


        public void MatchUpdateMenu()
        {
            var match = mr.GetMatchById(getint("Enter match id: "));
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Match Update Menu ===");
                Console.WriteLine("1 - Update Team 1 rounds");
                Console.WriteLine("2 - Update Team 2 rounds");
                Console.WriteLine("3 - Update Match date");
                Console.WriteLine("4 - Update Tournament name");
                Console.WriteLine("0 - Back to Matches Menu");
                switch (getint("Your choice: "))
                {
                    case 0:
                        mr.SaveChanges();
                        Console.WriteLine("Back to Match Menu...");
                        return;
                    case 1:
                        match.team1_Rounds = getint("Enter new Team 1 rounds: ");
                        break;
                    case 2:
                        match.team2_Rounds = getint("Enter new Team 2 rounds: ");
                        break;
                    case 3:
                        match.Date = GetDateOnly("Enter new match date YYYY-MM-DD: ");
                        break;
                    case 4:
                        match.Tournament_Name = getstring("Enter new Tournament name: ");
                        break;
                    default:
                        Console.WriteLine("Enter from 0 to 4");
                        break;
                }
            }
        }



        public void Team_Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Team Menu===");
                Console.WriteLine("1 - Add Team");
                Console.WriteLine("2 - Update Team");
                Console.WriteLine("3 - Remove Team");
                Console.WriteLine("4 - Show Team");
                Console.WriteLine("5 - Show All Teams");
                Console.WriteLine("0 - Back to Main Menu");
                switch (getint("Your choice: "))
                {
                    case 0:
                        Console.WriteLine("Back to Main Menu...");
                        return;
                    case 1:
                        tr.Add();
                        break;
                    case 2:
                        TeamUpdateMenu();
                        break;
                    case 3:
                        tr.RemoveById(getint("Enter removable team id: "));
                        break;
                    case 4:
                        tr.ShowTeamWithId(getint("Enter team id: "));
                        break;
                    case 5:
                        tr.ShowAll();
                        break;
                    default:
                        Console.WriteLine("Enter a number from 0 to 3");
                        break;
                }
            }
        }


        public void TeamUpdateMenu()
        {
            var team = tr.GetTeamById(getint("Enter team id: "));   
            while(true)
            {
                Console.Clear();
                Console.WriteLine("=== Team Update Menu ===");
                Console.WriteLine("1 - Update name");
                Console.WriteLine("2 - Update Majors won");
                Console.WriteLine("3 - Update foundingdate");
                Console.WriteLine("0 - Back to Team Menu");
                switch (getint("Your choice: "))
                {
                    case 0:
                        tr.SaveChanges();
                        Console.WriteLine("Back to Team Menu...");
                        return;
                    case 1:
                        team.Name = getstring("Enter new name: ");
                        break;
                    case 2:
                        team.MajorWon = getint("Enter new Major won: ");
                        break;
                    case 3:
                        team.Foundingdate = GetDateOnly("Enter new founding date YYYY-MM-DD: ");
                        break;
                    default:
                        Console.WriteLine("Enter from 0 to 3");
                        break;
                }
            }    
        }


        public string getstring(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }


        public int getint(string message)
        {
            int tries = 0;
            while(tries < 3)
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

                if(DateOnly.TryParse(Console.ReadLine(),out DateOnly result))
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
