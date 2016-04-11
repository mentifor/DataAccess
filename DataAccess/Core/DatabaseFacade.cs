using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class DatabaseFacade
    {
        protected string connectionString;
        private readonly Type connectionType;

        public DatabaseFacade(Type connectionType, string connectionString)
        {
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString));

            this.connectionType = connectionType;
            this.connectionString = connectionString;
        }

        #region ExecuteReader
        public DbDataReader ExecuteReader(string commandText, CommandType commandType, IEnumerable<DbParameter> parameters)
        {
            using (DbConnection connection = CreateConnection())
            {
                return ExecuteReaderInternal(connection, commandText, commandType, parameters);
            }
        }

        private DbDataReader ExecuteReaderInternal(DbConnection connection, string commandText, CommandType commandType, IEnumerable<DbParameter> parameters)
        {
            var command = BuildCommand(connection, commandText, commandType, parameters);

            if (connection.State != ConnectionState.Open)
                connection.Open();

            try
            {
                return command.ExecuteReader();
            }
            catch (DbException)
            {
                throw;
            }
        }
        #endregion

        private DbCommand BuildCommand(DbConnection connection, string commandText, CommandType commandType, IEnumerable<DbParameter> parameters)
        {
            var command = connection.CreateCommand();
            command.CommandText = commandText;
            command.CommandType = commandType;
            command.CommandTimeout = connection.ConnectionTimeout;

            AttachParameters(command, parameters);

            return command;
        }

        private void AttachParameters(DbCommand command, IEnumerable<DbParameter> parameters)
        {
            if (parameters == null)
                return;

            foreach (var parameter in parameters)
            {
                if (parameter.Direction != ParameterDirection.Output && parameter.Value == null)
                    parameter.Value = DBNull.Value;

                command.Parameters.Add(parameter);
            }
        }

        public abstract DbConnection CreateConnection();

        public abstract DbParameter CreateParameter();
    }
}
