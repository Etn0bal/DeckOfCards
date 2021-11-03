using System.Collections.Generic;

namespace DeckOfCards {
    public class Deck {

        public List<Card> Cards { get; set; }

        public Deck() {
            InitializeDeck();
        }

        private void InitializeDeck()
        {
            Cards = new List<Card>();
            for (int i = 0; i < 4; ++i)
            {
                Suit suit = (Suit) i;
                for (int j = 1; j < 14; ++j)
                {
                    Value val = (Value) j;
                    Cards.Add(new Card(val, suit));
                }
            }
        }
    }
}