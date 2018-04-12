using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionVerify
{
    class BoolHandler
    {
        public static bool BoolEqivalance(Expression ex)
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
            string result = "";

            //Handle parenthesis
            List<string> substring = new List<string>();
            int beginLoc = Side.IndexOf("(");
            int lastLoc = Side.IndexOf(")");

            if (beginLoc != -1 && lastLoc != -1)
            {
                for (int i = beginLoc + 1; i < lastLoc; i++)
                    substring.Add(Side[i]);

                int count = substring.Count + 2;
                result = HandleMultAndAdd(substring);
                Side.RemoveRange(beginLoc, count);
                Side.Insert(beginLoc, result);
            }


            result = HandleMultAndAdd(Side);

            return result;
        }

        public static string HandleMultAndAdd(List<string> Side)
        {
            string result = "";

            //Handle Multiplications first
            for (int i = 0; i < Side.Count; i++)
            {
                if (Side[i].ToString() == "*")
                {
                    result = MultiplyBool(Side[i - 1], Side[i + 1]); //get the result
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
                    result = AddBool(Side[i - 1], Side[i + 1]); //get the result
                    //Remove the old stuff and replace with the new result
                    Side.RemoveAt(i - 1);
                    Side[i - 1] = result;
                    Side.RemoveAt(i);
                    i = 0; //Restart loop
                }
            }

            return result;
        }

        public static string AddBool(string a, string b)
        {   //Or
            if (a == "1" || b == "1")
                return "1";
            else
                return "0";
        }

        public static string MultiplyBool(string a, string b)
        {   //And
            if (a == "1" && b == "1")
                return "1";
            else
                return "0";
        }



    }
}