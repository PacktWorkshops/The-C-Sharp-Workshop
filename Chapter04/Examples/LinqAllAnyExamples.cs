using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter04.Examples
{
    enum PlayingCardSuite
    {
        Hearts,
        Clubs,
        Spades,
        Diamonds
    }

    record PlayingCard (int Number, PlayingCardSuite Suite)
    {
        public override string ToString()
        {
            return $"{Number} of {Suite}";
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
                _cards.Add(new PlayingCard(i, PlayingCardSuite.Hearts));
                _cards.Add(new PlayingCard(i, PlayingCardSuite.Clubs));
                _cards.Add(new PlayingCard(i, PlayingCardSuite.Spades));
                _cards.Add(new PlayingCard(i, PlayingCardSuite.Diamonds));
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

            Console.WriteLine($"Any Clubs: {hand.Any(card => card.Suite == PlayingCardSuite.Clubs)}");
            Console.WriteLine($"Any Red: {hand.Any(card => card.Suite == PlayingCardSuite.Hearts || card.Suite == PlayingCardSuite.Diamonds)}");
            Console.WriteLine($"All Diamonds: {hand.All(card => card.Suite == PlayingCardSuite.Diamonds)}");
            Console.WriteLine($"All Even: {hand.All(card => card.Number % 2 == 0)}");
            Console.WriteLine($"Score :{hand.Sum(card => card.Number)}");
        }
    }
}
