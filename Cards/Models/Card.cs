using Cards.Enums;

namespace Cards.Models
{
    public class Card
    {
        private const int TrumpCardAddedValue = 100;
        public Card(CardType suite, CardValue value)
        {
            Suite = suite;
            Value = value;
        }
        public CardType Suite { get; }
        public CardValue Value { get; }

        public int GetValue(CardType trumpSuit)
            => (int)Value + (Suite == trumpSuit ? TrumpCardAddedValue : 0);

    }
}
