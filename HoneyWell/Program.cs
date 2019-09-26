using System;
using System.Collections.Generic;

namespace HoneyWell
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var n = Int32.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            Dictionary<char, int> dic = new Dictionary<char, int>();
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                dic[input[i]] += 1;
            }
            for (int i = 0; i < dic.Count; i++)
            {
                dic[input[i]] += 1;
            }
            foreach (var item in dic)
            {
                if (item.Value / 2 == 0)continue;
                if (item.Value / 2 == 1) count++;
            }
        }
    }

    
}
