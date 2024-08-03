using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Books
{
    public class BookVersion: AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid? BookId { get; set; }
        public Book Book { get; set; }
    }
}
