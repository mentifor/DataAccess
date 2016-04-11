using Core;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace MsSql.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DatabaseFacade database;

        public MessageRepository(DatabaseFacade database)
        {
            this.database = database;
        }

        public IEnumerable<Message> GetMessages(int articleId)
        {
            throw new NotImplementedException();
        }
    }
}
