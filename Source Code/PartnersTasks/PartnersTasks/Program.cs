using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PartnersTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputLi = File.ReadAllLines("input.txt").ToList<string>();
            for (int cur = 0; cur < inputLi.Count; cur++)
            {
                string[] inputs = inputLi[cur].Split(',');
                int x, a, b, numOfA, numOfB;
                x = Convert.ToInt32(inputs[0]);
                a = Convert.ToInt32(inputs[1]);
                b = Convert.ToInt32(inputs[2]);
                numOfA = Convert.ToInt32(inputs[3]);
                numOfB = Convert.ToInt32(inputs[4]);
                if (numOfA > numOfB)
                {
                    swap(ref a, ref b);
                    swap(ref numOfA, ref numOfB);
                }

                int[][] records = new int[numOfA][];
                for (int i = 0; i < numOfA; i++)
                {
                    records[i] = new int[numOfB];
                }

                for (int i = 0; i < numOfA; i++)
                {
                    for (int j = 0; j < numOfB; j++)
                    {
                        int rowTotal = total(i, records, true), colTotal = total(j, records, false);
                        if (rowTotal < a && colTotal < b)
                        {
                            int var;
                            var = min((a - rowTotal), (b - colTotal));
                            records[i][j] = var < x ? var : x;
                        }
                    }
                }
                int grandTotal = 0;
                for (int i = 0; i < numOfA; i++)
                {
                    for (int j = 0; j < numOfB; j++)
                    {
                        grandTotal += records[i][j];
                    }
                }
                Console.WriteLine(grandTotal);
            }
        }
        static void swap(ref int A, ref int B)
        {
            int temp = A;
            A = B;
            B = temp;
        }
        static int total(int index, int[][] records, bool ifRow)
        {
            int sum = 0;
            if (ifRow)
                for (int i = 0; i < records[0].GetLength(0); i++)
                    sum += records[index][i];
            else
                for (int i = 0; i < records.GetLength(0); i++)
                {
                    sum += records[i][index];
                }
            records.GetLength(0);
            return sum;
        }
        static int min(int a, int b)
        {
            return a < b ? a : b;
        }

    }
}
