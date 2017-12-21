using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class String_TitalCase
    {
        //Write algorithm that accepts a string and returns the Title Case version of the string.
            
        //Acceptance Criteria:
            
        //1. Always capitalize the first word in a title
        //2. Always capitalize the last word in a title
        //3. Lowercase the following words, unless they are the first or last word in the title:
        //"a", "the", "to", "at", "in", "with", "and", "but", "or"
        //4. Capitalize any words not listed in #3

        public static void Init()
        {
            //Test 1;        
            string titleCase = TitleCase("i love solving problems and it is fun!");
            if (titleCase != "I Love Solving Problems and It Is Fun!")
                //throw new  Exception("Not Title Case: " + titleCase);
                Console.WriteLine("Not Title Case: " + titleCase);
            //Test 2
            titleCase = TitleCase("a day IN the liFe of a sOFtwAre deVELOper");        
            if (titleCase != "A Day in the Life Of a Software Developer")
                //throw new Exception("Not Title Case: " + titleCase);
                Console.WriteLine("Not Title Case: " + titleCase);
        }
    
    
        static string TitleCase(string title)
        {
            //Store all the words those are not to be capitalized
            List<string> donotCapitalize = new List<string>();
            donotCapitalize.Add("a");
            donotCapitalize.Add("the");
            donotCapitalize.Add("to");
            donotCapitalize.Add("at");
            donotCapitalize.Add("in");
            donotCapitalize.Add("with");
            donotCapitalize.Add("and");        
            donotCapitalize.Add("but");
            donotCapitalize.Add("or");        
        
            //Split given string into each word
            string[] splitString = title.Split(' ');        
            StringBuilder capilizedString = new StringBuilder();        
        
            for(int i=0; i<splitString.Length; i++)
            {
                //First word and last word are always capitalized
                if(i==0 || i == splitString.Length-1)
                {
                    capilizedString.Append(CapitalizedWord(splitString[i]));
                }
                else
                {
                    if(donotCapitalize.Contains(splitString[i].ToLower()))
                        capilizedString.Append(splitString[i].ToLower());
                    else
                        capilizedString.Append(CapitalizedWord(splitString[i]));
                }            
        
                capilizedString.Append(" ");
            }
        
            title = capilizedString.ToString().Trim();
            return title;
        }
    
        static public string CapitalizedWord(string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1).ToLower();
        }
    }
}
