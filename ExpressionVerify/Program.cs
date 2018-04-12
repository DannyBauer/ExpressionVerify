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
            LinkedList<string> expressionTypeTracker = new LinkedList<string>(); //when we are in a certain tag we can push to this list the tag we are in 
                                                                                 // and when we leave the tag pop out the tag so we go back to the previous tag
                                                                                 // so to know what current tag we are in just look at the top of the list
            expressionTypeTracker.AddLast("NoTag");                                                             
            string line;
            StreamReader file = new StreamReader("expressions.txt");
            while ((line = file.ReadLine()) != null)
            {
                List<char> lineCharList = new List<char>();

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
                    foreach (char c in line)
                    {
                        if (c != ' ')
                            lineCharList.Add(c);
                    }
                    foreach (char c in lineCharList)
                    {
                        Console.Write(c);
                    }

                    if (expressionTypeTracker.Last.Value == "strings")
                        StringEqivalance(lineCharList);


                }
                Console.WriteLine(expressionTypeTracker.Last());
            }

            while (true) { }
        }

        public static bool StringEqivalance(List<char> Line)
        {
            List<char> leftSide = new List<char>();
            List<char> rightSide = new List<char>();

            //Populate the leftside and rightside lists of the equation
            bool setLeft = true;
            foreach(var digit in Line)
            {
                if (digit.ToString() == "=") { 
                    setLeft = false;
                    continue; //Skip the = sign
                }
                if (setLeft)
                    leftSide.Add(digit);
                else
                    rightSide.Add(digit);
            }

            //Simplify the results down to a single string 
            string leftResult = SimplifySide(leftSide);
            string rightResult = SimplifySide(rightSide);

            //Compare and return results
            return (leftResult == rightResult);
        }

        public static string SimplifySide(List<char> Side)
        {

            return "ay";
        }



        public static string MultiplyString(string s, int multiplier)
        {
            string adder = s;
            for (int i = 0; i < (multiplier - 1); i++)
            {
                s = s + adder;
            }

            return s;
        }
    }
}
