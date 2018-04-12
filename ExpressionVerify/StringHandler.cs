using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionVerify
{
    static class StringHandler
    {

        public static bool StringEqivalance(Expression Line)
        {
            List<string> results = new List<string>();

            //Convert to a list of strings
            List<string> working = new List<String>();

            //Get the result from each side


            //Compare and return results
            return true;
        }

        public static string SimplifySide(List<string> Side)
        {
            string result = "";

            //Handle parenthesis

            //Handle Multiplications first
            for (int i = 0; i < Side.Count; i++)
            {
                if (Side[i].ToString() == "*")
                {
                    result = MultiplyString(Side[i - 1], Side[i + 1]); //get the result
                    //Remove the old stuff and replace with the new result
                    Side.RemoveAt(i - 1);
                    Side[i - 1] = result;
                    Side.RemoveAt(i);
                    i = 0; //Restart loop
                }
            }

            //Handle additions next
            for (int i = 0; i < Side.Count; i++)
            {
                if (Side[i].ToString() == "+")
                {
                    result = AddString(Side[i - 1], Side[i + 1]); //get the result
                    //Remove the old stuff and replace with the new result
                    Side.RemoveAt(i - 1);
                    Side[i - 1] = result;
                    Side.RemoveAt(i);
                    i = 0; //Restart loop
                }
            }

            return result;
        }

        public static string AddString(string a, string b)
        {
            return a + b;
        }

        public static string MultiplyString(string a, string multiplier)
        {
            string result = a;
            int mult = Int32.Parse(multiplier);

            for (int i = 0; i < mult - 1; i++)
                result += a;

            return result;
        }















    }
}
