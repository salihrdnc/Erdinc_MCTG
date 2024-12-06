using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erdinc_MCTG.Models
{
    public class User
    {
        public int UserId { get; protected set; }
        public string? Username { get; protected set; }
        public string? Password { get; protected set; }
        public int Coins { get; protected set; } = 20;
        public string Token => $"{Username}-msgToken";

        public UserStack UserStack { get; protected set; } = new UserStack();
        public Deck Deck { get; protected set; } = new Deck();

        public User(int userId, string? username, string? password, int coins)
        {
            UserId = userId;
            Username = username;
            Password = password;
            Coins = coins;
        }

        public bool BuyPackage()
        {
            if (Coins >= 5)
            {
                Coins -= 5;
                List<Card> newCards = GenerateCards();
                UserStack.AddCards(newCards);
                return true;
            }
                return false;
        }

        private List<Card> GenerateCards()
        {
            List<Card> cards = new List<Card>();
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                bool isMonster = random.Next(0, 2) == 0;
                ElementType elementType = (ElementType)random.Next(0, 3);

                if (isMonster)
                {
                    cards.Add(new MonsterCard(i, $"Card {i + 1}", random.Next(10, 100), elementType));
                }
                else
                    cards.Add(new SpellCard(i, $"Card {i + 1}", random.Next(10, 100), elementType));
            }
            return cards;
        }

        public void TopFourCards()
        {

        }
    }
}
