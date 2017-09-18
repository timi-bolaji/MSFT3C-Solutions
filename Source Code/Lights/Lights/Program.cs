using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lights
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find how many perfect squares there are in a number
            List<string> inputData = File.ReadAllLines("input.txt").ToList<string>();

            for (int cur = 0; cur < inputData.Count; cur++)
            {
                int num = Convert.ToInt32(inputData[cur]);
                List<int> perfectSquares = new List<int>();
                for (int i = 1; ; i++)
                {
                    int sq = i * i;
                    if (sq < num)
                        perfectSquares.Add(sq);
                    else
                        break;
                }
                int ans = num - perfectSquares.Count;
                Console.WriteLine(ans);
            }
        }
    }
}
