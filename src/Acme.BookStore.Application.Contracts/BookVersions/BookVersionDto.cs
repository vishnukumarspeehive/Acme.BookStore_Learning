using Acme.BookStore.Books;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.BookVersions
{
    public class BookVersionDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid? BookId { get; set; }
      
    }
}
