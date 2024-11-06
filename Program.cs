using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rangoli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //      ----c----
            //      --c-b-c--
            //      c-b-a-b-c
            //      --c-b-c--
            //      ----c----

            // The whole idea of this solution lies on dependancies between chars, strings and number of desired dashes.
            // We start from negative index of desired letter and use Math.Abs(). For the 1-st string we need just one letter, so we
            // have to reflect the index. With incrementation of strings we change the reflection point for letters. In the very middle
            // where string counter becomes 0 - we have complete set of letters (ex.: c-b-a-b-c, gotten from indexes (-2),(-1),0,1,2).
            // When we needed "c-b-c" on previos string, our point was 1, so reflection came at (-1) instead of 0. ((-2),(-1),2).
            // Any positive point (after midlane string) will cause the same outcome because we compare Absolute values.

            // As far I understand there're dozens of solutions for this task. Mine one is based on dependencies between elements of rhombus.

            int size = Convert.ToInt32(Console.ReadLine());
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int strLoop = -(size - 1);
            int chrLoop;

            // external loop for assembling strings
            while (strLoop < size)
            {
                Console.Write(new string('-', Math.Abs(strLoop * 2))); // number of side dashes is dependant on string's count (left side)
                chrLoop = -(size - 1); // chars count initialization in each external loop

                while (chrLoop < size) //internal loop for creating each desired letter
                {
                    if (Math.Abs(chrLoop) == Math.Abs(strLoop)) { chrLoop = -chrLoop; } // some way to reflect char's count value if needed

                    //check for the last char in string, after which it's not supposed to place a dash
                    if (chrLoop == size - 1) { Console.Write(alphabet[chrLoop]); }
                    else                     { Console.Write(alphabet[Math.Abs(chrLoop)] + "-"); }

                    chrLoop++;
                }

                Console.WriteLine(new string('-', Math.Abs(strLoop * 2))); // number of side dashes is dependant on string's count (right side)
                strLoop++;
            }
            Console.ReadKey();
        }
    }
}
