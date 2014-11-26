using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamminCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Data: ");
            string cod = Console.ReadLine();
            Console.WriteLine("Hamming Code: ");
            Console.WriteLine(hamming(cod));
            Console.WriteLine("Check Hamming Code: ");
            String s = Console.ReadLine();
            CheckHamminCode(ref s);
        }

        private static void CheckHamminCode(ref string code)
        {
            int k;
            if (Math.Floor(Math.Log(code.Length, 2)) == Math.Log(code.Length, 2))
                k = (int)Math.Floor(Math.Log(code.Length, 2));
            else k = (int)Math.Floor(Math.Log(code.Length, 2)) + 1;
            int[] p = ParityBits(code, k);
            int check = 0;
            for (int i = 0; i < k; i++)
            {
                if (p[i] % 2 != 0)
                    check += (int)Math.Pow(2, i);
            }
            if (check != 0)
            {
                char[] x = code.ToArray();
                Console.WriteLine(string.Format("The {0} bit is incorrect!!", check));
                if (code[check - 1] == '0')
                    x[check - 1] = '1';
                else
                    x[check - 1] = '0';

                code = new string(x);
                Console.WriteLine("The code was fixed:" + code );
            }
            else Console.WriteLine("Correct code!");
        }


        private static string hamming(string cod)
        {
            int k = 0;
            while (Math.Pow(2, k) < cod.Length + k + 1)
                k++;
            string newCod = "2";
            int i = 2;
            int j = 0;
            int a = 1;

            while (i <= cod.Length + k)
            {
                if (i == Math.Pow(2, a))
                {
                    newCod += "2";
                    a++;
                }
                else
                {
                    newCod += cod[j];
                    j++;
                }
                i++;
            }
            int[] p = ParityBits(newCod, k);
            char[] c = newCod.ToArray();
            newCod = "";

            for (i = 0; i < k; i++)
            {
                if (p[i] % 2 == 0)
                    c[(int)Math.Pow(2, i) - 1] = '0';
                else c[(int)Math.Pow(2, i) - 1] = '1';
            }

            for (i = 0; i < c.Length; i++)
                newCod += c[i];

            return newCod;
        }

        public static int[] ParityBits(String newCod, int k)
        {
            int[] p = new int[k];
            int i, j;
            for (i = 1; i <= k; i++)
            {
                int p2 = (int)Math.Pow(2, i - 1);
                j = p2 - 1;
                while (j < newCod.Length)
                {
                    int l = 0;
                    while (l < p2 && j < newCod.Length)
                    {
                        if (newCod[j] == '1')
                            p[i - 1]++;
                        l++;
                        j++;
                    }
                    j += p2;
                }
            }
            return p;
        }
    }
}
