using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter04.Examples
{
    enum PlayingCardSuit
    {
        Hearts,
        Clubs,
        Spades,
        Diamonds
    }

    record PlayingCard (int Number, PlayingCardSuit Suit)
    {
        public override string ToString()
        {
            return $"{Number} of {Suit}";
        }
    }

    class Deck
    {
        private readonly List<PlayingCard> _cards = new();
        private readonly Random _random = new();

        public Deck()
        {
            for (var i = 1; i <= 10; i++)
            {
                _cards.Add(new PlayingCard(i, PlayingCardSuit.Hearts));
                _cards.Add(new PlayingCard(i, PlayingCardSuit.Clubs));
                _cards.Add(new PlayingCard(i, PlayingCardSuit.Spades));
                _cards.Add(new PlayingCard(i, PlayingCardSuit.Diamonds));
            }
        }

        public PlayingCard Draw()
        {
            var index = _random.Next(_cards.Count);
            var drawnCard = _cards.ElementAt(index);
            _cards.Remove(drawnCard);

            return drawnCard;
        }
    }

    class LinqAllAnyExamples
    {

        public static void Main()
        {
            var deck = new Deck();
            var hand = new List<PlayingCard>();
            
            for (var i = 0; i < 3; i++)
            {
                hand.Add(deck.Draw());
            }

            var summary = string.Join(" | ", 
                hand.OrderByDescending(c => c.Number)
                    .Select(c => c.ToString()));
            Console.WriteLine($"Hand: {summary}");

            Console.WriteLine($"Any Clubs: {hand.Any(card => card.Suit == PlayingCardSuit.Clubs)}");
            Console.WriteLine($"Any Red: {hand.Any(card => card.Suit == PlayingCardSuit.Hearts || card.Suit == PlayingCardSuit.Diamonds)}");
            Console.WriteLine($"All Diamonds: {hand.All(card => card.Suit == PlayingCardSuit.Diamonds)}");
            Console.WriteLine($"All Even: {hand.All(card => card.Number % 2 == 0)}");
            Console.WriteLine($"Score :{hand.Sum(card => card.Number)}");
        }
    }
}
