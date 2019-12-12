using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.PL.Helpers
{

    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }
    }

    public static class Extension
    {
        public static bool Operator(this string logic, float x, int y)
        {
            switch (logic)
            {
                case ">": return x > y;
                case ">=": return x >= y;
                case "<": return x < y;
                case "<=": return x <= y;
                case "=": return x == y;
                default: throw new Exception("invalid logic");
            }
        }
    }
}
