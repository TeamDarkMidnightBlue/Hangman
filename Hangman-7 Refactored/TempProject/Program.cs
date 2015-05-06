using System;
using System.Collections.Generic;
using System.Linq;

namespace TempProject
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] test = new char[] { 'a', 'b', 'c' };
            Console.WriteLine(new string(test));

            List<int> scores = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, };
            Console.WriteLine(scores.Max());
        }
    }
}
