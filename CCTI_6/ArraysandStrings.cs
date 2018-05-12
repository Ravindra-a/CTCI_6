using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCTI_6
{
    public static class ArraysandStrings
    {
        /// <summary>
        /// first duplicate character using array O(n) but no space optimization
        /// </summary>
        public static void Question1UniqueCharacersMethod1()
        {
            string input = Console.ReadLine();

            int[] temp = new int[256];
            bool duplicateFound = false;

            foreach(char c in input)
            {
                if(temp[Convert.ToInt32(c)] == 0)
                {
                    temp[Convert.ToInt32(c)] = 1;                    
                }
                else
                {
                    Console.WriteLine("duplicate found");
                    duplicateFound = true;
                    break;
                }
            }
            if(!duplicateFound)
                Console.WriteLine("no duplicates");
        }

        /// <summary>
        /// Most optimized bit manipulation
        /// </summary>
        public static void Question1UniqueChars()
        {
            string input = Console.ReadLine();
            var checker = 0;
            bool duplicateFound = false;
            foreach (char c in input)
            {
                var val = c - 'a';
                if((checker & (1 << val)) > 0)
                {
                    Console.WriteLine("duplicate found");
                    duplicateFound = true;
                    break;
                }
                checker = checker | 1 << val;
            }

            if (!duplicateFound)
                Console.WriteLine("no duplicates");
        }

        /// <summary>
        /// Find if 2 strings are anagrams
        /// </summary>
        public static void AdditionalQuestion2StringsAreAnagrams()
        {
            
            string a = Console.ReadLine();
            string b = Console.ReadLine();

            #region Method1
            //foreach (char c in a)
            //{
            //    foreach (char d in b)
            //    {
            //        if (c == d)
            //        {
            //            a = a.Remove(a.IndexOf(c), 1);
            //            b = b.Remove(b.IndexOf(d), 1);
            //            break;
            //        }
            //    }
            //}

            //Console.WriteLine(a.Length + b.Length);

            #endregion

            #region Method2
            int[] charCounta = GetCharCount(a);
            int[] charCountb = GetCharCount(b);
            Console.WriteLine(GetDelta(charCounta, charCountb));
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="charCounta"></param>
        /// <param name="charCountb"></param>
        /// <returns></returns>
        private static int GetDelta(int[] charCounta, int[] charCountb)
        {
            if (charCounta.Length != charCountb.Length)
                return -1;
            int delta = 0;
            for(int i=0;i<charCounta.Length;i++)
            {
                if(charCounta[i] != charCountb[i])
                {
                    delta = delta + Math.Abs(charCounta[i] - charCountb[i]);
                }
            }
            return delta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static int[] GetCharCount(string input)
        {
            int[] temp = new int[26];
            foreach(char c in input)
            {
                temp[c - 'a']++;
            }

            return temp;
        }

        /// <summary>
        /// Left rotation
        /// INPUT
        /// 5 4
        /// 1 2 3 4 5
        /// OUTPUT
        /// 5 1 2 3 4
        /// </summary>
        public static void AdditionalQuestionLeftrotation()
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            int[] temp = new int[n];
            for (int i = 0; i < n; i++)
            {
                temp[i] = a[i];
            }
            if (k >= n)
            {
                k = k % n;
            }
            for (int i = 0; i < n; i++)
            {
                if ((i + k) < n)
                {
                    a[i] = temp[i + k];
                }
                else
                {
                    a[i] = temp[i + k - n];
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + " ");
            }

        }
        
        
    }
}
