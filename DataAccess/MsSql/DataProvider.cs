using Core;
using Interfaces;
using MsSql.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsSql
{
    public class DataProvider : IDataProvider
    {
        public IMessageRepository MessageRepository { get; }

        public DataProvider(string connectionString)
        {
            var database = new SqlDatabaseFacade(connectionString);

            MessageRepository = new MessageRepository(database);
        }
    }
}
