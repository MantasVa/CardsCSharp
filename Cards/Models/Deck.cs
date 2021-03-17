using System;
using System.Collections.Generic;
using System.Linq;
using Cards.Enums;

namespace Cards.Models
{
    public class Deck
    {
        private List<Card> cardDeck = new List<Card>();
        public int Count => cardDeck.Count;
        public bool IsShuffled { get; private set; } = false;

        public Deck()
        {
            CreateDeck();
        }

        public (List<Card>, List<Card>) DealCards()
        {
            Shuffle();
            if (Count == 0 || !IsShuffled || Count % 2 == 1)
            {
                throw new Exception("Deck is empty or not shuffled or count is not equal number");
            }
            int halfCount = Count / 2;
            List<Card> player1Deck = TakeCardsSkipAmount(halfCount);
            List<Card> player2Deck = TakeCardsSkipAmount(halfCount, halfCount);

            return (player1Deck, player2Deck);
        }

        public List<Card> TakeCardsSkipAmount(int takeAmount, int skipAmount = 0)
        {
            return takeAmount < 0 || skipAmount < 0
                ? throw new ArgumentException("Arguments are negative")
                : takeAmount + skipAmount > cardDeck.Count
                    ? throw new ArgumentException("Arguments are more than data count")
                    : cardDeck.Skip(skipAmount).Take(takeAmount).ToList();
        }

        public void Shuffle()
        {
            var random = new Random();
            for (int i = cardDeck.Count - 1; i > 0; i--)
            {
                int randomIndex = random.Next(0, i + 1);

                Card tempSlot = cardDeck[randomIndex];
                cardDeck[randomIndex] = cardDeck[i];
                cardDeck[i] = tempSlot;
            }
            IsShuffled = true;
        }

        private void CreateDeck()
        {
            cardDeck = Enumerable.Range(1, 4)
                    .SelectMany(s => Enumerable.Range(2, 13)
                                        .Select(c => new Card((CardType)s, (CardValue)c)))
                    .ToList();
        }
    }
}
