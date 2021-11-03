using System;
using Xunit;
using FluentAssertions;

namespace DeckOfCards.Tests
{
    public class DeckTests
    {
        [Fact]
        public void DeckInitialization_ShouldCreateCards()
        {
            var deck = new Deck();

            deck.Cards.Count.Should().Be(52);
        }
    }
}
