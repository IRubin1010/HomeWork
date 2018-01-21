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
            int[][] d = new int[3][];
            DateTime da = new DateTime(1990, 1, 1);
            Console.WriteLine(da.ToString("dd/MM/yyyy"));
            int aaaa = new int();
            aaaa = 5;
            int bbbb = new int();
            bbbb =    aaaa;
            bbbb = 3;
            Console.WriteLine(aaaa);
            Console.WriteLine(bbbb);
            Console.ReadKey();
        }
    }
    public class A
    {
        private int b;
        public int a { get { return b; } set { } }
        public int[][] c = new int[3][];
        public A Clone()
        {
            return (A)MemberwiseClone();
        }
    }
}
