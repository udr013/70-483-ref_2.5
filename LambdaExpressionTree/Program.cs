using System;
using System.Linq.Expressions;

namespace LambdaExpressionTree
{
    class Program
    {
        static void Main(string[] args)
        {
            //buid the expression tree (immutable):
            //Expression<Func<int, int>> square = num => num * num;

            //the parameter for the expression is an intager
            ParameterExpression numParam = Expression.Parameter(typeof(int), "num");

            //the operation to be preformed is to square the parameter
            BinaryExpression squareOperation = Expression.Multiply(numParam, numParam);

            //This creates an expression tree that describes the square operation
            Expression<Func<int, int>> square = Expression.Lambda<Func<int, int>>(squareOperation, 
                new ParameterExpression[] { numParam });

            //Compile the tree to make an executable method and assign itto a delegate
            Func<int, int> doSquare = square.Compile();

            //Call the delegate
            Console.WriteLine("Square of 2: {0}", doSquare(2));

            MultiplyToAdd multiply = new MultiplyToAdd();
            Expression<Func<int, int>> addExpression = (Expression<Func<int, int>>)multiply.Modify(square);
            
            //Compile
            Func<int, int> doAdd = addExpression.Compile();

            Console.WriteLine("Double of 4: {0}", doAdd(4));
        }
    }
}
