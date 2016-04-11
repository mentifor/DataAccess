using Core;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsSql.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DatabaseFacade database;

        public MessageRepository(DatabaseFacade database)
        {
            this.database = database;
        }

        public bool CreateMessage(string text)
        {
            throw new NotImplementedException();
        }
    }
}
