using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionVerify
{
    class SetHandler
    {

        public static bool SetEqivalance(Expression ex)
        {
            List<string> results = new List<string>();

            //Get the result from each side
            foreach (var side in ex.expressions)
                results.Add(SimplifySide(side));

            for (int i = 0; i < results.Count; i++)
            {
                //Reached the end, stop checking
                if (i == results.Count - 1)
                    break;
                //if one isnt equal to the following, it is not equivalent
                if (results[i + 1] != results[i])
                    return false;
            }
            return true;
        }

        public static string SimplifySide(List<string> Side)
        {         
            return "ay";
        }

        public static string HandleMultAndAdd(List<string> Side)
        {            
            return "ay";
        }

        public static string AddSet(string a, string b)
        {
            return a + b;
        }

        public static string MultiplySet(string a, string multiplier)
        {
            string result = a;
            int mult = Int32.Parse(multiplier);

            for (int i = 0; i < mult - 1; i++)
                result += a;

            return result;
        }
    }
}
