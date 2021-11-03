namespace DeckOfCards {
    public class Card
    {
        private readonly Suit _suit;
        private readonly Value _value;

        public Card(Value value, Suit suit) {
            _value = value;
            _suit = suit;
        }

        public override string ToString()
        {
            string suitSymbol = _suit switch
            {
                Suit.Clubs => "♣",
                Suit.Diamonds => "♦",
                Suit.Hearts => "♥",
                Suit.Spades => "♠"
            };
            int intValue = (int)_value;
            string parsedValue = InBetween(intValue, 2, 10) ? intValue.ToString() : _value.ToString();

            return $"{parsedValue} of {suitSymbol}";
        }

        private bool InBetween(int value, int minValue, int maxValue) => value >= minValue && value <= maxValue;
    }
}