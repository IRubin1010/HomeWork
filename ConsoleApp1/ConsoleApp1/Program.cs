using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            a.a = 5;
            A b = a.Clone();
            Console.WriteLine(a.a);
            Console.WriteLine(b.a);
            b.a = 10;
            Console.WriteLine(a.a);
            Console.WriteLine(b.a);
        }
    }
    public class A
    {
        public int? a { get; set; }
        public A Clone()
        {
            return (A)MemberwiseClone();
        }
    }
}
