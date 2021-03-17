using System;
using System.Collections.Generic;
using System.Linq;
using Cards.Enums;
using Cards.Models;

namespace Cards
{
    public class Game
    {
        private readonly (int minValue, int maxValue) trumpSuitValueRange;
        private readonly CardType trumpSuit;

        private readonly Player player1;
        private readonly Player player2;

        public Game()
        {
            trumpSuitValueRange = (1, 4);
            trumpSuit = (CardType)new Random().Next(trumpSuitValueRange.minValue, trumpSuitValueRange.maxValue);

            var deck = new Deck();
            (List<Card> hand1, List<Card> hand2) playerHands = deck.DealCards();
            player1 = new Player(playerHands.hand1);
            player2 = new Player(playerHands.hand2);
        }

        public void PlayGame()
        {
            while (player1.Hand.Any() && player2.Hand.Any())
            {
                TakeTurn();
            }
        }

        public Player GetWinner()
        {
            return player1.Hand.Count == 0
                    ? player1.WinningCards.Count > player2.WinningCards.Count
                        ? player1
                        : player2
                    : throw new InvalidOperationException("Game is not over yet");
        }

        private void TakeTurn()
        {
            Card player1Card = player1.TakeCard();
            Card player2Card = player2.TakeCard();
            int player1CardValue = player1Card.GetValue(trumpSuit);
            int player2CardValue = player2Card.GetValue(trumpSuit);

            if (player1CardValue > player2CardValue)
            {
                player1.WinningCards.Add(player1Card);
                player1.WinningCards.Add(player2Card);
            }
            else if (player1CardValue < player2CardValue)
            {
                player2.WinningCards.Add(player1Card);
                player2.WinningCards.Add(player2Card);
            }
            else
            {
                player1.WinningCards.Add(player1Card);
                player2.WinningCards.Add(player2Card);
            }
        }
    }
}
