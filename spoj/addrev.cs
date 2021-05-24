using System;


namespace _SPOJ_AddingReversedNumbers
{
    //http://www.spoj.com/problems/ADDREV/

    class Program
    {
        static void Main(string[] args)
        {
            string[] s;
            int i = int.Parse(Console.ReadLine());

            while (i > 0)
            {
                s = Console.ReadLine().Split(' ');
                Console.WriteLine(Reverse(Reverse(int.Parse(s[0])) + Reverse(int.Parse(s[1]))));
                i--;
            }
        }

        static int Reverse(int k)
        {
            int result = 0;
            string s = k.ToString();

            for (int i = s.Length - 1; i >= 0; i--)
            {
                result = result * 10 + int.Parse(s[i].ToString());
            }

            return result;
        }
    }
}
