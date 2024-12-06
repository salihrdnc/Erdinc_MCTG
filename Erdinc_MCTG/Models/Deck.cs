using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erdinc_MCTG.Models
{
    public class Deck
    {
        public int DeckId { get; protected set; }
        public int UserId { get; protected set; }
        public List<Card>? Cards { get; protected set; }

    }
}
