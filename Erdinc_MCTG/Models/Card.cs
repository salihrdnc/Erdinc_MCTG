using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erdinc_MCTG.Models;

namespace Erdinc_MCTG.Models
{
    public abstract class Card
    {
        public int CardId { get; protected set; }
        public string? CardName { get; protected set; }
        
        public readonly int Damage;
        public ElementType ElementType { get; protected set; }

        public MonsterCard MonsterCard { get; protected set; }
        public SpellCard SpellCard { get; protected set; }

        protected Card(int cardId, string? cardName, int damage, ElementType elementType)
        {
            CardId = cardId;
            CardName = cardName;
            Damage = damage;
            ElementType = elementType;
        }
    }
    public enum ElementType
    {
        Normal,
        Fire,
        Water
    }
}
