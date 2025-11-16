using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMatchesManager.DAL.Entities
{
    public class Statistic
    {
        public int Id { get; set; }

        public int Kills { get; set; }

        public int Deaths { get; set; }

        public int Assists { get; set; }

        public int HSRate { get; set; }

        public float AVGDamage { get; set; }

        public int Match_id { get; set; }

        public int Player_id { get; set; }

        public Players Player { get; set; }

        public Matches Match { get; set; }
    }
}
