using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LambdaExpressionTree
{
    class MultiplyToAdd : ExpressionVisitor
    {
        public Expression Modify(Expression expression)
        {
            return Visit(expression);
        }

        protected override Expression VisitBinary(BinaryExpression b)
        {
            if(b.NodeType == ExpressionType.Multiply)
            {
                Expression left = this.Visit(b.Left);
                Expression right = this.Visit(b.Right);

                //Make this binary expression an Add rather than a multiply operation.
                return Expression.Add(left, right);
            }

            return base.VisitBinary(b);
            }
        }
    }
}
