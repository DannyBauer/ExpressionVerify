using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionVerify
{
    class AlgebraHandler
    {
        public static bool AlbegraEquivilence(Expression expression)
        {
            List<double> results = new List<double>();
            foreach (List<string> ex in expression.expressions)
            {
                string stringExpression = String.Join(String.Empty, ex);
                results.Add(Evaluate(stringExpression));
            }

            return true;
        }

        public static double Evaluate(string expression)
        {
            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), expression);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string)row["expression"]);
        }
    }
}
