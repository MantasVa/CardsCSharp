using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Models
{
    public class Player
    {
        public List<Card> Hand { get; }
        public List<Card> WinningCards { get; }

        public Player(List<Card> hand)
        {
            Hand = hand;
            WinningCards = new List<Card>();
        }

        public Card TakeCard()
        {
            Card card = Hand.FirstOrDefault();
            if (card is null)
            {
                throw new InvalidOperationException("No cards in hand");
            }
            _ = Hand.Remove(card);
            return card;
        }
    }
}
