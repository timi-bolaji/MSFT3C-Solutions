using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Energy
{
    class Program
    {
         enum state
        {
            OFF,
            WARMUP,
            ON
        }
        static void Main(string[] args)
        {
            List<string> inputData = File.ReadLines("input.txt").ToList<string>();
            
            for (int cur = 0; cur < inputData.Count; cur++)
            {
                string[] input = inputData[cur].Split(',');
                int start, target, variance, minutes;
                start = Convert.ToInt32(input[0]);
                target = Convert.ToInt32(input[1]);
                variance = Convert.ToInt32(input[2]);
                minutes = Convert.ToInt32(input[3]);


                if (Math.Abs(start - target) > variance || ((target - start) == variance))
                {
                    Console.WriteLine("not possible");
                    continue;
                }

                state curState = state.OFF;

                //Console.WriteLine("Possible");
                int curTemp = start;
                int units = 0;

                if (curTemp - 1 == target-variance)
                {
                    curState = state.WARMUP;
                }

                for (int i = 0; i < minutes; i++)
                {
                    
                    if (curState == state.OFF)
                    {
                        if (target - curTemp == variance - 2)
                        {
                            curState = state.WARMUP;
                            if (minutes - i  < 3)
                                curState = state.OFF;
                        }
                        curTemp--;
                        continue;
                    }
                    else if (curState == state.ON)
                    {
                        units += 10;
                        if (curTemp + 1 == target + variance)
                        {
                            curState = state.OFF;
                        }
                        if (minutes - (i + 2) <= (curTemp - (target - variance)))
                            curState = state.OFF;
                        curTemp++;
                        continue;
                    }
                    else if (curState == state.WARMUP)
                    {
                        curTemp--;
                        units += 5;
                        curState = state.ON;
                        continue;
                    }

                }

                Console.WriteLine(units);
                        
            }

        }
    }
}
