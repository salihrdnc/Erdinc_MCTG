using System.Globalization;

namespace Erdinc_MCTG.Models
{
    public class Battle
    {
        public int BattleId { get; protected set; }
        public int User1Id { get; protected set; }
        public int User2Id { get; protected set; }
        public int WinnerId { get; protected set; }
        public string? BatteLog { get; protected set; }

        public User? User1 { get; protected set; }
        public User? User2 { get; protected set; }
        public List<Card>? UserDeck1 { get; protected set; }
        public List<Card>? UserDeck2 { get; protected set; }


    }
}