using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int ArticleId { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
