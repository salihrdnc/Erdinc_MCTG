using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erdinc_MCTG.DB;

namespace Erdinc_MCTG.Models
{
    public class Trade
    {
        public int TradeId { get; set; }
        public int UserId { get; set; }
        public int OfferedCardId { get; set; }
        public MonsterCard? RequiredType1 { get; set; }
        public MonsterCard? RequiredType2 { get; set; }
        public int MinDamage { get; set; }
        public User? User { get; set; }
        public Card? OfferedCard { get; set; }

        public Deck Deck
        {
            get => default;
            set { }
        }
    }
}
