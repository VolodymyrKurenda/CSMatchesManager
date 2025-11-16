using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMatchesManager.DAL.Entities
{
    public class Teams
    {
        public int Id { get; set; }

        public int MajorWon { get; set; }

        public string Name { get; set; }

        public DateOnly Foundingdate { get; set; }

        public List<Players> Players { get; set; } = new();

        public List<Teams_Match> Team1_Matches { get; set; } = new();

        public List<Teams_Match> Team2_Matches { get; set; } = new();
    }
}
