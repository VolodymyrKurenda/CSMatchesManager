using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMatchesManager.DAL.Entities
{
    public class Matches
    {
        public int id { get; set; }

        public int team2_Rounds { get; set; }

        public int team1_Rounds { get; set; }

        public DateOnly Date { get; set; }

        public string Tournament_Name { get; set; }

        public List<Teams_Match> Teams_Matches { get; set; } = new();

        public List<Statistic> Stats { get; set; } = new();

    }
}
