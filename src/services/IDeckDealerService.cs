namespace DeckOfCards {
    public interface IDeckDealerService {
        Card DealOneCard();

        void ChangeDeck(Deck deck);

        void Shuffle();
    }
}