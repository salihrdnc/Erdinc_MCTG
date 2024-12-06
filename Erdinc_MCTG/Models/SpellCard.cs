namespace Erdinc_MCTG.Models
{
    public class SpellCard : Card
    {
        public SpellCard(int cardId, string? cardName, int damage, ElementType elementType) : base(cardId, cardName, damage, elementType)
        {
        }
    }
}