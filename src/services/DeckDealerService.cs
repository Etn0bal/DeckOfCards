namespace DeckOfCards {
    public class DeckDealerService {
        private Deck _deck { get; set; }

        public DeckDealerService(Deck deck)
        {
            _deck = deck;
        }

        public Card DealOneCard()
        {
            if (_deck.Cards.Count <= 0)
                return null;

            Card card = _deck.Cards[0];
            _deck.Cards.RemoveAt(0);

            return card;
        }

    }
}