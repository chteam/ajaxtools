/*
created by zou jian
*/
using System.Linq.Expressions;

namespace MvcAjaxToolkit
{
    static public class ExpressionExtensions
    {
        public static Expression RemoveUnary(this Expression body)
        {
            var uniary = body as UnaryExpression;
            return uniary != null ? uniary.Operand : body;
        }
    }
}