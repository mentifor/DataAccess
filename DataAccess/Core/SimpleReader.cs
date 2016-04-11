using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class SimpleReader<T> : Reader<T>
        where T : class
    {
        private readonly Func<DbDataReader, T> entityReader;
        public SimpleReader(Func<DbDataReader, T> reader)
        {
            entityReader = reader;
        }
        public override List<T> LoadList(DbDataReader reader)
        {
            var result = new List<T>();

            if (reader!=null)
            {
                while (reader.Read())
                    result.Add(entityReader(reader));
            }

            return result;
        }
    }
}
