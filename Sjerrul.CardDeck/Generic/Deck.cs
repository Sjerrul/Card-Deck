using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sjerrul.CardDeck.Generic
{
    public class Deck
    {
        const int LOWEST_VALUE = 2;
        const int HIGHEST_VALUE = 14;
        
        private Stack<Card> _cards = new Stack<Card>();
        private int _numberLeftInDeck = 0;

        public bool HasCardsLeft {
            get {
                return _numberLeftInDeck != 0;
            }
        }

        public Deck()
        {
            AddFullSuit(Suit.Clubs);
            AddFullSuit(Suit.Diamonds);
            AddFullSuit(Suit.Hearts);
            AddFullSuit(Suit.Spades);
        }

        public void Split(out Deck deck1, out Deck deck2)
        {
            if (_numberLeftInDeck % 2 != 0)
            {
                throw new NotSupportedException("This deck cannot be split evenly");
            }

            int middle = _numberLeftInDeck / 2;
            deck1 = new Deck(_cards.Take(middle));
            deck2 = new Deck(_cards.Skip(middle).Take(middle));
        }

        public Deck(IEnumerable<Card> cards)
        {
            foreach (Card card in cards)
            {
                _cards.Push(card);
                _numberLeftInDeck++;
            }
        }

        private void AddFullSuit(Suit suit)
        {
            for (int i = LOWEST_VALUE; i <= HIGHEST_VALUE; i++)
            {
                _cards.Push(new Card(suit, i));
                _numberLeftInDeck++;
            }
        }

        public void Shuffle()
        {
            Card[] cards = _cards.ToArray();

            //Fisher-Yates
            Random r = new Random();
            for (int n = cards.Length - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                Card temp = cards[n];
                cards[n] = cards[k];
                cards[k] = temp;
            }

            _cards = new Stack<Card>(cards);
        }

        public Card TakeTopCard()
        {
            _numberLeftInDeck--;

            return _cards.Pop();
        }
    }
}
