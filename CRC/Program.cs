using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRC
{
    class Program
    {
        static void Main(string[] args)
        {
            String mess = "";
            String gener = "";
            Console.WriteLine("Message: ");
            mess = Console.ReadLine();
            Console.WriteLine("Generator: ");
            gener = Console.ReadLine();
            string newMess = CRC(mess, gener);
            Console.WriteLine(newMess);
            Console.WriteLine("Check Message: ");
            newMess = Console.ReadLine();
            if (CRCCheck(newMess, gener) == true)
                Console.WriteLine("Message checked sucessfully.");
            else Console.WriteLine("Message check failed.");
        }
        public static string CRC(string message, string generator)
        {
            int l = generator.Length;
            string newMess = message;
            while (l > 1)
            {
                message += "0";
                l--;
            }
            newMess += CRCGetValue(message, generator);
            return newMess;
        }

        public static int xor(char a, char b)
        {
            if (a != b)
                return 1;
            return 0;
        }


        public static String CRCGetValue(String message, String generator)
        {
            int i = 0;
            char[] newMess = message.ToCharArray();
            while (i < newMess.Length - generator.Length + 1)
            {
                if (newMess[i] == '1' || i == 0)
                {
                    int j = 0;
                    while (j < generator.Length)
                    {
                        if (xor(newMess[i + j], generator[j]) == 1)
                            newMess[i + j] = '1';
                        else newMess[i + j] = '0';
                        j++;
                    }
                    if (i == 0 && newMess[i] != '1')
                        i++;
                }
                else i++;
            }
            message = new string(newMess);
            //System.out.println(mess.substring(mess.length() - gener.length() +1));
            return message.Substring(message.Length - generator.Length + 1);
        }

        public static bool CRCCheck(String message, String generator)
        {
            String checkValue = CRCGetValue(message, generator);
            String s = "";
            int i = 0;
            while (i < generator.Length - 1)
            {
                s += "0";
                i++;
            }

            return checkValue == s;
        }

    }
}
