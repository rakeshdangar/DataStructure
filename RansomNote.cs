using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class RansomNote
    {
        public static void Init()
        {
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();

            //Check if strings are empty
            if (string.IsNullOrEmpty(str1) && string.IsNullOrEmpty(str2))
                throw new ArgumentNullException("arguments are empty or null, cannot find if one list is sub set of another list");
            if (string.IsNullOrEmpty(str2))
                Console.WriteLine("List one **{0}** is not a subset of another list **{1}**", str1, str2);
            else if (string.IsNullOrEmpty(str1))
                Console.WriteLine("List one **{0}** is a subset of another list **{1}**", str1, str2);
            else
            {
                //Insert all element of first list into dictionary
                Dictionary<string, int> str1Content = new Dictionary<string, int>();
                //Keep couner
                int number_of_unique_element = 0;
                int number_completed_element = 0;

                foreach (string s in str1.Split(new char[] { ' ' }).ToList())
                {
                    if (!str1Content.ContainsKey((s)))
                    {
                        str1Content.Add(s, 1);
                        ++number_of_unique_element;
                    }
                    else
                    {
                        ++str1Content[s];
                    }
                }

                foreach (string s in str2.Split(new char[] { ' ' }).ToList())
                {
                    if (str1Content.ContainsKey(s))
                    {
                        --str1Content[s];
                        if (str1Content[s] == 0)
                            ++number_completed_element;

                        if (number_of_unique_element == number_completed_element)
                        {
                            Console.WriteLine("List one **{0}** is a subset of another list **{1}**", str1, str2);
                            break;
                        }
                    }
                }
            }
        }
    }
}
