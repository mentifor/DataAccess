using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public sealed class SqlDatabaseFacade : DatabaseFacade
    {
        public SqlDatabaseFacade(string connectionString)
            :base(typeof(SqlConnection), connectionString)
        {
        }

        public override DbConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }

        public override DbParameter CreateParameter()
        {
            return new SqlParameter();
        }
    }
}
