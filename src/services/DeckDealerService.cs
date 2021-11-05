using System;

namespace DeckOfCards {
    public class DeckDealerService : IDeckDealerService {
        private Deck _deck { get; set; }
        private readonly Random _random;

        public DeckDealerService(Deck deck)
        {
            _deck = deck;
            _random = new Random();
        }

        public Card DealOneCard()
        {
            if (_deck.Cards.Count <= 0)
                return null;

            Card card = _deck.Cards[0];
            _deck.Cards.RemoveAt(0);

            return card;
        }

        public void ChangeDeck(Deck deck)
        {
            _deck = deck;
        }

        public void Shuffle()
        {
            if (_deck.Cards.Count == 0)
                throw new Exception("The deck doesn't contain any card to shuffle");

            for (int i = _deck.Cards.Count - 1; i > 0; i--)
            {
                int n = _random.Next(i + 1);
                SwapCards(i, n);
            }
        }

        private void SwapCards(int firstCardIndex, int secondCardIndex)
        {
            Card tempCard = _deck.Cards[firstCardIndex];
            _deck.Cards[firstCardIndex] = _deck.Cards[secondCardIndex];
            _deck.Cards[secondCardIndex] = tempCard;
        }
    }
}