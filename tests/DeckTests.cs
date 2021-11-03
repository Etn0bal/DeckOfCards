using System;
using Xunit;
using FluentAssertions;

namespace DeckOfCards.Tests
{
    public class DeckTests
    {
        [Fact]
        public void DefaultTest()
        {
            true.Should().BeTrue();
        }
    }
}
