using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Enigma_Decryption
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputData = File.ReadAllLines("input.txt").ToList<string>();
            string outputHex = "";
            string outputStr = "";
            List<string> rings = new List<string>();
            for (int i = 0; i < 3; i++)
                rings.Add(inputData[i]);
            string code = inputData[3];

            for (int itr = 0; itr < code.Length; itr++)
            {
                List<int> ringInts = new List<int>();
                for (int i = 0; i < 3; i++)
                    ringInts.Add(Int32.Parse(rings[i][0].ToString(), NumberStyles.HexNumber));

                int ringSum = 0;
                foreach (var item in ringInts)
                    ringSum += item;
                ringSum = ringSum % 16;

                int codevar = Int32.Parse(code[itr].ToString(),NumberStyles.HexNumber);
                if (codevar >= ringSum)
                    outputHex += (codevar - ringSum).ToString("x");
                else
                    outputHex += ((16 + codevar) - ringSum).ToString("x");
                int foo = maxRing(ringInts);
                rings[foo] = rotateString(rings[foo]);
                
            }
            for (int i = 0; i < outputHex.Length; i+=2)
            {
                string hs = outputHex.Substring(i, 2);
                outputStr += Convert.ToChar(Convert.ToUInt32(hs, 16));
            }
            Console.WriteLine(outputStr);
        }
        static string rotateString(string t)
        {
            return t.Substring(1, t.Length - 1) + t.Substring(0, 1);
        }
        static int maxRing(List<int> ringInts)
        {
            if (ringInts[0] > ringInts[1])
            {
                if (ringInts[2] > ringInts[0])
                    return 2;
                if (ringInts[0] > ringInts[2])
                    return 0;
                else
                    return 0;
            }
            if (ringInts[1] > ringInts[0])
            {
                if (ringInts[2] > ringInts[1])
                    return 2;
                if (ringInts[1] > ringInts[2])
                    return 1;
                else
                    return 1;
            }
            else
            {
                if (ringInts[2] > ringInts[1])
                {
                    return 2;
                }
                else
                    return 0;
            } 

        }
    }
}
