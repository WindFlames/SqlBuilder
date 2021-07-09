using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SqlBuilder
{
    public  class Transform
    {
        public static string BuilderEach(string sql)
        {
            if(string.IsNullOrEmpty(sql))return string.Empty;
            if(sql.Contains("@{DATABASE}"))//数据库名
            {
                sql = sql.Replace("@{DATABASE}", DistinguishName.GetDatabaseName());
            }
            Regex regex = new Regex(@"\{(?<name>[a-zA-Z_@#][\w@$#_]*)\}", RegexOptions.Compiled);
            regex.Replace(sql, $"{BasicInfo.FullName}_${{name}}{BasicInfo.Group}");
            regex = new Regex(@"@\{(?<name>[a-zA-Z_@#][\w@$#_]*)\}", RegexOptions.Compiled);
            regex.Replace(sql, $"{BasicInfo.ShortName}_${{name}}{BasicInfo.Group}");

            //{}表名
            //@{}属性名
            return sql;

        }
        public static string BuilderFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            return BuilderEach(File.ReadAllText(path));
        }
    }
}
