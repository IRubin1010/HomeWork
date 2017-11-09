using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace targil2
{
    enum E_Color { red, blak }

    class Card : IComparable
    {
        private E_Color color;
        public E_Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        private int number;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value >= 2 && value <= 14)
                {
                    number = value;
                }
                else
                {

                }
            }
        }
        public string CardName
        {
            get
            {
                switch (number)
                {
                    case 11:
                        return "Jack";
                        break;
                    case 12:
                        return "Queen";
                        break;
                    case 13:
                        return "King";
                        break;
                    case 14:
                        return "Ace";
                        break;
                    default:
                        return number.ToString();
                        break;
                }
            }
        }
        public Card() { }
        public Card(E_Color col,int num) // constractor
        {
            color = col;
            number = num;
        }
        public override string ToString() { return CardName + " " + Color; } // override To string
        public int CompareTo(object obj) // implement CompareTo
        {
            Card card = obj as Card;
            if (card == null) throw new ArgumentException("object is not a card");
            return number.CompareTo(card.Number);
        }
    }
}
