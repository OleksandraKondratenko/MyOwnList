using System;
using System.Collections.Generic;
using MyOwnList;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> list1 = new List<int>() { 6, 8, 9, 10, 25, 78, 12, 45, 25 };
            MyList<int> list = new MyList<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Add(40);

            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i]} ");
            }
            Console.WriteLine(list.Count);

            list.DelPos(4);

            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i]} ");
            }
            Console.WriteLine(list.Count);

            //Console.WriteLine(list.Count);
            //list.Clear();
            //Console.WriteLine(list.Count);


            //string output = list[2].ToString();

            //Console.WriteLine(output);

            //List<int> originList = new List<int>();
            //originList.Add(7);
            //originList.Add(147);
            //originList.Add(-1234);
            //originList.Add(105);

            //Console.WriteLine(originList[0].ToString());

            
        }
    }
}
