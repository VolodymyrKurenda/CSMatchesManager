using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSMatchesManager.DAL.Entities
{
    public class Teams_Match
    {
        public int ID { get; set; }

        public int Team1_id { get; set; }

        public int Team2_id { get; set; }

        [ForeignKey("Team1_id")]
        public Teams Team1 { get; set; }

        [ForeignKey("Team2_id")]
        public Teams Team2 { get; set; }

        public int MatchID { get; set; }

        public Matches Matches { get; set; }
    }
}
