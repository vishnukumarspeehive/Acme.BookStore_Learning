using Acme.BookStore.Books;
using Acme.BookStore.EntityFrameworkCore;
using Acme.BookStore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.BookStore.CustomRepositories
{
    public class BookRepository : EfCoreRepository<BookStoreDbContext, Book, Guid>, IBookRepository
    {
        IDbContextProvider<BookStoreDbContext> _dbContext;
        public BookRepository(IDbContextProvider<BookStoreDbContext> dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Book>> GetBooksWithVersionDetailsAsync()
        {
            // Use the DbContextProvider to get the DbContext
            var dbContext = await _dbContext.GetDbContextAsync();

            // Query the Book DbSet and include the Author navigation property
            return await dbContext.Books
                .Include(b => b.BookVersion) // Include navigation property
                .ToListAsync();
        }
        public async Task<List<Book>> GetBooksWithVersionDetailsAsync(Func<Book, bool> predicate = null)
        {
            // Use the DbContextProvider to get the DbContext
            var dbContext = await _dbContext.GetDbContextAsync();

            // Query the Book DbSet and include the BookVersion navigation property
            var query = dbContext.Books
                .Include(b => b.BookVersion) // Include navigation property
                .AsQueryable(); // Convert to IQueryable for dynamic filtering

            // Apply the predicate if provided
            if (predicate != null)
            {
                query = query.Where(predicate).AsQueryable();
            }

            return await query.ToListAsync(); // Ensure you have `using Microsoft.EntityFrameworkCore;`
        }


    }
}
