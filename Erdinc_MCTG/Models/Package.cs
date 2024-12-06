using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erdinc_MCTG.Models
{
    public class Package
    {
        public int PackageId { get; protected set; }
        public int Price { get; protected set; } = 5;

        public List<Card> Cards { get; protected set; }
        public Package(int packageid, List<Card> cards)
        {
            PackageId = packageid;
            Cards = cards;
        }
    }
}
