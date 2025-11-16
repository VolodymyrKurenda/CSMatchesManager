using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMatchesManager.DAL.Entities
{
    public class Players
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string NickName { get; set; }

        public float Rating { get; set; }

        public float KD { get; set; }

        public int Firepower { get; set; }

        public int Sniping { get; set; }

        public string GameRole { get; set; }

        public int Team_id { get; set; }

        public Teams Team { get; set; }

        public List<Statistic> Statistics { get; set; } = new();

        public Rewards Rewards { get; set; }

    }
}
