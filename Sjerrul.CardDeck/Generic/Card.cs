using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sjerrul.CardDeck.Generic
{
    public class Card
    {
        private Suit _suit;
        private int _value;

        internal Card(Suit suit, int number)
        {
            _suit = suit;
            _value = number;
        }

        public override string ToString()
        {
            return String.Format("{0} of {1}", this.GetName(), _suit);
        }

        private string GetName()
        {
            switch (_value)
            {
                case 11: return "Jack";
                case 12: return "Queen";
                case 13: return "King";
                case 14: return "Ace";
                default: return _value.ToString();
            }

        }

        public bool IsHigherValueThan(Card otherCard)
        {
            return _value > otherCard._value;
        }

        public bool IsEqualValue(Card otherCard)
        {
            return _value == otherCard._value;
        }
    }
}
