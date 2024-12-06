using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Erdinc_MCTG.Models
{
    public class UserStack
    {
        public int UserStackId { get; protected set; }
        public int UserId { get; protected set; }
        public List<Card> Cards { get; set; } = new List<Card>();

        public void AddCards(List<Card> addCards)
        {
            Cards.AddRange(addCards);
        }

        public void RemoveCards(List<Card> removeCards)
        {
            foreach (Card card in removeCards)
                if (Cards.Contains(card))
                    Cards.Remove(card);
                else
                    Console.WriteLine("Die Karte esxistiert nicht im Stack!");
        }

    }
}