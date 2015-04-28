using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlSharp.Expressions
{
    public enum ExpressionType
    {
        Column,
        ColumnList,
        ColumnName,
        Name,
        SqlSelect,
        Table,
        TableJoin,
        TableList,
        TableName,
        Where
    }
}
