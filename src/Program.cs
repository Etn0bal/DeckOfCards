using System;
using System.Diagnostics.CodeAnalysis;

namespace DeckOfCards
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();

            DeckDealerService deckDealerService = new DeckDealerService(deck);

            deckDealerService.Shuffle();

            Console.WriteLine(deckDealerService.ToString());
        }
    }
}
