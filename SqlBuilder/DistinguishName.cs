using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlBuilder
{
    public static class DistinguishName
    {
        public static string GetDatabaseName()
        {
            return $"{BasicInfo.FullName}MIS{BasicInfo.Group:d2}";
        }
        public static string GetTableName([NotNull] string tablename)
        {
            return $"{BasicInfo.FullName}_{tablename}{BasicInfo.Group:d2}";
        }
        public static string GetFieldName([NotNull] string fieldName)
        {
            return $"{BasicInfo.ShortName}_{fieldName}{BasicInfo.Group:d2}";
        }
    }
}
