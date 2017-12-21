using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class String_ReverseWordsInAString
    {
        public static void Init()
        {
            String_ReverseWordsInAString.ReverseWords("the sky is blue");
        }

        private static void ReverseWords(string input) 
        {
            int i=0;
            char[] s = input.ToCharArray();
            for(int j=0; j<s.Length; j++){
                if(s[j]==' '){
                    Reverse(s, i, j - 1);        
                    i=j+1;
                }
            }
 
            //Reverse last word.
            Reverse(s, i, s.Length-1);
 
            //Revers entire string.
            Reverse(s, 0, s.Length - 1);
        }
 
        private static void Reverse(char[] s, int i, int j)
        {
            while(i<j){
                char temp = s[i];
                s[i]=s[j];
                s[j]=temp;
                i++;
                j--;
            }
        }
    }
}
