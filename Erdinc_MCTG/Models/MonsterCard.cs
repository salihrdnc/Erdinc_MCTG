namespace Erdinc_MCTG.Models
{
    public class MonsterCard : Card
    {
        public MonsterCard(int cardId, string cardName, int damage, ElementType elementType) : base(cardId, cardName, damage, elementType)
        {
        }
    }
}