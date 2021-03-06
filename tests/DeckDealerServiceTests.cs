using System;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;

namespace DeckOfCards.Tests
{
    public class DeckDealerServiceTests
    {
        [Fact]
        public void DeckDealerServiceDealOneCard_ShouldReturnFirstCardCorrectly()
        {
            Deck deck = new Deck();
            Card card = new Card(Value.Ace, Suit.Spades);
            deck.Cards = new List<Card> { card };

            DeckDealerService service = new DeckDealerService(deck);

            service.DealOneCard().Should().Be(card);
            deck.Cards.Count.Should().Be(0);
        }

        [Fact]
        public void DeckDealerServiceDealOneCard_ShouldReturnNullIfNoCardsLeft()
        {
            Deck deck = new Deck();
            deck.Cards = new List<Card>();

            DeckDealerService service = new DeckDealerService(deck);

            service.DealOneCard().Should().BeNull();
        }

        [Fact]
        public void DeckDealerServiceChangeDeck_ShouldChangeDeckParameterCorrectly()
        {
            Deck deck = new Deck();
            deck.Cards = new List<Card>();

            Deck newDeck = new Deck();
            Card card = new Card(Value.Ace, Suit.Spades);
            newDeck.Cards = new List<Card>() { card };

            DeckDealerService service = new DeckDealerService(deck);

            service.ChangeDeck(newDeck);

            service.DealOneCard().Should().Be(card);
        }

        [Fact]
        public void DeckDealerServiceShuffle_ShouldChangeTheDeckCardsOrder()
        {
            Deck deck = new Deck();
            List<Card> cards = new List<Card>(deck.Cards);

            DeckDealerService service = new DeckDealerService(deck);

            service.Shuffle();

            deck.Cards.Should().NotEqual(cards);
        }

        [Fact]
        public void DeckDealerServiceShuffle_ShouldThrowIfNoCard()
        {
            Deck deck = new Deck();
            List<Card> cards = new List<Card>();
            deck.Cards = cards;

            DeckDealerService service = new DeckDealerService(deck);

            Action act = () => service.Shuffle();

            act.Should().Throw<Exception>();
        }
    }
}