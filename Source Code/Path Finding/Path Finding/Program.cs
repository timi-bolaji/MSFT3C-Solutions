using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Path_Finding
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = File.ReadAllLines("InputFile.txt").ToList<string>();
            string text = input[0];
            List<List<char>> map = new List<List<char>>();
            for (int i = 1; i < input.Count; i++)
            {
                map.Add(new List<char>());
                map[i-1] = input[i].ToCharArray().ToList<char>();
            }
        }
    }
}
