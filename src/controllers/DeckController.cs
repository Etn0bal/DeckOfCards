using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.CodeAnalysis;

namespace DeckOfCards
{
    [ApiController]
    [Route("[controller]")]
    [ExcludeFromCodeCoverage]
    public class DeckController : ControllerBase
    {
        private readonly IDeckDealerService _deckDealerService;
        public DeckController(IDeckDealerService deckDealerService)
        {
            _deckDealerService = deckDealerService;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<string> DealCard()
        {
            Card card = _deckDealerService.DealOneCard();

            if (card == null)
                return NotFound("The deck doesn't contain any card");

            return Ok(card.ToString());
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<string> Shuffle()
        {
            try 
            {
                _deckDealerService.Shuffle();
                return Ok("Cards were shuffled successfully");
            } 
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<string> ChangeDeck()
        {
            Deck newDeck = new Deck();

            _deckDealerService.ChangeDeck(newDeck);

            return Ok("The deck has been changed for a new one");
        }
    }
}