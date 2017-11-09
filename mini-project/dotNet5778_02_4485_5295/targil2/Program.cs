using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace targil2
{
    class Program
    {
        static void Main(string[] args)
        {
            Card a = new Card();
            string s = a.CardName;
            CardStock c = new CardStock();
            Console.WriteLine(c.ToString());
            c.Mix();
            Console.WriteLine(c.ToString());
            c.SortCards();
            Console.WriteLine(c.ToString());
            foreach(Card card in c)
            {

            }
            //foreach(Card card in c.CerdsProperty)
            //{
            //    Console.WriteLine(card.ToString())
            //}
            Player p = new Player();
          
        }
    }
}
