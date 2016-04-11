using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class Loader<T>
        where T : class
    {
        public abstract List<T> LoadList(DbDataReader reader);
    }
}
