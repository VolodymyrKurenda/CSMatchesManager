using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMatchesManager.DAL.Entities
{
    public class Rewards
    {
        public int Id { get; set; }

        public int Majors { get; set; }

        public int Cologne { get; set; }

        public int Katowice { get; set; }

        public int Grandslam { get; set; }

        public int ESL { get; set; }

        public int HLTV_TOP_1 { get; set; }

        public int Player_id { get; set; }
        public Players Player { get; set; }
    }
}
