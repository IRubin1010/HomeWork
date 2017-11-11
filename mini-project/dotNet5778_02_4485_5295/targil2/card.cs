using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace targil2
{
    // enum for the color
    enum E_Color { red, black }

    // class for card, inherits from IComparable interfase
    class Card : IComparable
    {
        private E_Color color;
        private int number;
        // constractor 
        public Card(E_Color col, int num)
        {
            color = col;
            number = num;
        }
        // color ptoperty
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
        // number property
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
            }
        }
        // property who get back the card name
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
        // override ToString
        public override string ToString() { return CardName + " " + Color; }
        // implement CompareTo in order to implement IComparable 
        public int CompareTo(object obj)
        {
            Card card = obj as Card; // get the card object from "obj"
            if (card == null) throw new ArgumentException("object is not a card"); // if obj wasn't card
            return number.CompareTo(card.Number); // use int.CompareTo to compare the number of the card
        }
    }
}
