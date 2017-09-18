using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dinner_Bowl
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputData = File.ReadAllLines("input.txt").ToList<string>();
            int testNum = Convert.ToInt32(inputData[0]);
            int totPeople = 0;
            for (int cur = 0; cur < testNum; cur++)
            {
                int lineNum = 1 + totPeople + cur * 1;
                int peoplenum = Convert.ToInt32(inputData[lineNum]);
                totPeople += peoplenum;
                int[] timeArray = new int[peoplenum];
                for (int i = 0; i < peoplenum; i++)
                {
                    string[] currPerson = inputData[lineNum + i + 1].Split(' ');
                    timeArray[i] = Convert.ToInt32(currPerson[0]) + Convert.ToInt32(currPerson[1]);
                }
                int remTime = 240 - (10 + timeArray.Max());
                if (remTime < 0)
                {
                    remTime = 0;
                }
                Console.WriteLine(remTime);
            }
            Console.ReadKey();
        }
        
    }
}
