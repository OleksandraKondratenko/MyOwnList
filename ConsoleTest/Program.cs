using System;
using System.Collections.Generic;
using MyOwnList;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();
            list.Add(7);
            list.Add(147);

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"{list[i]}");
            }

            Console.WriteLine(list.Count);
            list.Clear();
            Console.WriteLine(list.Count);
            Array.M
        }
    }
}
