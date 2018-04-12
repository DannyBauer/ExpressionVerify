using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionVerify
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Expression> expressions = new List<Expression>();
            LinkedList<string> expressionTypeTracker = new LinkedList<string>(); //when we are in a certain tag we can push to this list the tag we are in 
                                                                                 // and when we leave the tag pop out the tag so we go back to the previous tag
                                                                                 // so to know what current tag we are in just look at the top of the list
            expressionTypeTracker.AddLast("NoTag");                                                             
            string line;
            StreamReader file = new StreamReader("expressions.txt");
            while ((line = file.ReadLine()) != null)
            {

                //check for beginning tag and add them to tracker 
                if (line.Contains("strings") && !line.Contains("/"))
                {
                    expressionTypeTracker.AddLast("strings");
                }
                else if (line.Contains("algebra") && !line.Contains("/"))
                {
                    expressionTypeTracker.AddLast("algebra");
                }
                else if (line.Contains("sets") && !line.Contains("/"))
                {
                    expressionTypeTracker.AddLast("sets");
                }
                else if (line.Contains("boolean") && !line.Contains("/"))
                {
                    expressionTypeTracker.AddLast("boolean");
                }

                //check for ennding tag and remove them from tracker
                else if (line.Contains("/"))
                {
                    expressionTypeTracker.RemoveLast();
                }
                
                else
                {
                    Expression ex = new Expression();
                    List<char> charList = new List<char>();

                    ex.type = expressionTypeTracker.Last();
                    foreach (char c in line)
                    {
                        if (c == '=')
                        {
                            ex.expressions.Add(charList);
                            charList = new List<char>();
                        }
                        else if (c != ' ')
                        {
                            charList.Add(c);
                        }

                    }
<<<<<<< HEAD
                    ex.expressions.Add(charList);
                    expressions.Add(ex);
=======

                    if (expressionTypeTracker.Last.Value == "strings")
                        StringEqivalance(lineCharList);


>>>>>>> 62a271eacf5924af7a755a0941dd11fb909addb3
                }
            }

            while (true) { }
        }

        public static bool StringEqivalance(List<char> Line)
        {
            List<string> leftSide = new List<string>();
            List<string> rightSide = new List<string>();

            //Populate the leftside and rightside lists of the equation
            bool setLeft = true;
            foreach(var digit in Line)
            {
                if (digit.ToString() == "=") { 
                    setLeft = false;
                    continue; //Skip the = sign
                }
                if (setLeft)
                    leftSide.Add(digit.ToString());
                else
                    rightSide.Add(digit.ToString());
            }

            //Simplify the results down to a single string 
            string leftResult = SimplifySide(leftSide);
            string rightResult = SimplifySide(rightSide);

            //Compare and return results
            return (leftResult == rightResult);
        }

        public static string SimplifySide(List<string> Side)
        {
            string result = "";

            //Handle parenthesis

            //Handle Multiplications first
            for(int i = 0; i < Side.Count; i++)
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
