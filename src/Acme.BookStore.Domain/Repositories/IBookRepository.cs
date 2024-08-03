using Acme.BookStore.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Repositories
{
    public interface IBookRepository: IRepository<Book, Guid>
    {
        Task<List<Book>> GetBooksWithVersionDetailsAsync();
        Task<List<Book>> GetBooksWithVersionDetailsAsync(Func<Book, bool> predicate = null);
    }
}
