using frac;
using System;

namespace frac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyFrac fr1 = new MyFrac(5, 10);
            Console.WriteLine(fr1.ToString());

            MyFrac fr2 = new MyFrac(3, -18);
            Console.WriteLine(fr2.ToString());

            Console.WriteLine(fr1.ToStringWithIntegerPart());
            Console.WriteLine(fr2.ToStringWithIntegerPart());

            Console.WriteLine(fr1.Add(fr2).ToStringWithIntegerPart());
            Console.WriteLine(fr1.Subtract(fr2).ToStringWithIntegerPart());
            Console.WriteLine(fr1.Multiply(fr2).ToStringWithIntegerPart());
            Console.WriteLine(fr1.Divide(fr2).ToStringWithIntegerPart());
        }
    }
}
