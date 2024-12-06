using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erdinc_MCTG.Models
{
    public class Statistics
    {
        public int UserId { get; protected set; }
        public int Wins { get; protected set; }
        public int Losses { get; protected set; }
        public int Elo { get; protected set; }

        public User? User { get; protected set; }

        public Battle? Battle { get; protected set; }


    }
}
