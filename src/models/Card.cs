namespace DeckOfCards {
    public class Card
    {
        private readonly Suit _suit;
        private readonly Value _value;
        
        public Card(Value value, Suit suit) {
            _value = value;
            _suit = suit;
        }
    }
}