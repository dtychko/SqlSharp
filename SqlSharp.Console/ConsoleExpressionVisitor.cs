using System;
using System.Linq;
using SqlSharp.Expressions;

namespace SqlSharp.Console
{
    public class ConsoleExpressionVisitor : ExpressionVisitor
    {
        private int _padding;


        protected override void VisitName(NameExpression expression)
        {
            System.Console.Write("[{0}]", expression.Value);
        }

        protected override void VisitColumnName(ColumnNameExpression expression)
        {
            System.Console.Write("[{0}]", expression.Value);
        }

        protected override void VisitTableName(TableNameExpression expression)
        {
            System.Console.Write("[{0}]", expression.Value);
        }

        protected override void VisitUnary(UnaryExpression expression)
        {
            throw new NotImplementedException();
        }

        protected override void VisitBinary(BinaryExpression expression)
        {
            Visit(expression.Left);
            switch (expression.NodeType)
            {
                case ExpressionType.ColumnList:
                case ExpressionType.TableList:
                    System.Console.Write(",\n{0}", WhiteSpace(_padding));
                    break;
                case ExpressionType.Column:
                case ExpressionType.Table:
                    System.Console.Write(" AS ");
                    break;
                default:
                    throw new NotSupportedException();
            }
            Visit(expression.Right);
        }

        protected override void VisitTableJoin(TableJoinExpression expression)
        {
            Visit(expression.Left);
            switch (expression.JoinType)
            {
                case JoinType.Inner:
                    System.Console.Write(" INNER JOIN\n{0}", WhiteSpace(_padding));
                    break;
                case JoinType.LeftOuter:
                    System.Console.Write(" LEFT OUTER JOIN\n{0}", WhiteSpace(_padding));
                    break;
                case JoinType.RightOuter:
                    System.Console.Write(" RIGHT OUTER JOIN\n{0}", WhiteSpace(_padding));
                    break;
                case JoinType.FullOuter:
                    System.Console.Write(" FULL JOIN\n{0}", WhiteSpace(_padding));
                    break;
                default:
                    throw new NotSupportedException();
            }
            Visit(expression.Right);
            System.Console.Write(" ON ");
            Visit(expression.Condition);
        }

        protected override void VisitWhere(WhereExpression expression)
        {
            System.Console.Write(expression.Value);
        }

        protected override void VisitSqlSelect(SqlSelectExpression expression)
        {
            System.Console.Write("SELECT ");
            _padding = 7;
            Visit(expression.Select);
            System.Console.WriteLine();
            System.Console.Write("FROM ");
            _padding = 5;
            Visit(expression.From);
            if (expression.Where != null)
            {
                System.Console.WriteLine();
                System.Console.Write("WHERE ");
                _padding = 6;
                Visit(expression.Where);
            }
        }


        private string WhiteSpace(int length)
        {
            return string.Concat(Enumerable.Repeat(" ", length));
        }
    }
}
