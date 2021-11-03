using System;
using Xunit;
using FluentAssertions;

namespace DeckOfCards.Tests
{
    public class CardTests
    {
        [Theory]
        [InlineData("Ace", "Spades", "Ace of ♠")]
        [InlineData("2", "Hearts", "2 of ♥")]
        [InlineData("10", "Diamonds", "10 of ♦")]
        [InlineData("Jack", "Clubs", "Jack of ♣")]
        public void CardToString_ShouldReturnCorrectValue(string _value, string _suit, string expectedOutput)
        {
            Value value = Enum.Parse<Value>(_value);
            Suit suit = Enum.Parse<Suit>(_suit);

            var card = new Card(value, suit);

            card.ToString().Should().Be(expectedOutput);
        }

        [Fact]
        public void CardToString_ShouldThrowIfNoSymbolForSuit()
        {
            var card = new Card(Value.Ace, (Suit) 4);

            Action act = () => card.ToString();

            act.Should().Throw<Exception>();
        }
    }
}
