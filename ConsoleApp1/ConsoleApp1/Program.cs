using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public delegate int someDelegate(int x, int y);

        static public int sum(int num1, int num2)
        {
            Console.WriteLine("sum( {0} , {1} )", num1, num2);
            return num1 + num2;
        }
        static public int mult(int num1, int num2)
        {
            Console.WriteLine("mult( {0} , {1} )", num1, num2);
            return num1 * num2;
        }
        static void Main(string[] args)
        {
            someDelegate myDelegate = new someDelegate(sum);
            someDelegate d2 = new someDelegate(mult);
            myDelegate += d2;
            int x = myDelegate(5, 5);
            Console.WriteLine(x);
            
        }
    }
}
