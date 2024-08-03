using Acme.BookStore.Books;
using Acme.BookStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore
{
    public class BookStoreDataSeederContributor
          : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IBookRepository _IbookRepository;

        private readonly IRepository<BookVersion, Guid> _bookVeraionRepository;

        public BookStoreDataSeederContributor(IRepository<Book, Guid> bookRepository, IRepository<BookVersion, Guid> bookVeraionRepository, IBookRepository ibookRepository)
        {
            _bookRepository = bookRepository;
            _bookVeraionRepository = bookVeraionRepository;
            _IbookRepository = ibookRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            var books = await _IbookRepository.GetBooksWithVersionDetailsAsync();


            if (await _bookRepository.GetCountAsync() <= 0)
            {
                var book1 = await _bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "1984",
                        Type = BookType.Dystopia,
                        PublishDate = new DateTime(1949, 6, 8),
                        Price = 19.84f
                    },
                    autoSave: true
                );

                var book2 = await _bookRepository.InsertAsync(
                     new Book
                     {
                         Name = "The Hitchhiker's Guide to the Galaxy",
                         Type = BookType.ScienceFiction,
                         PublishDate = new DateTime(1995, 9, 27),
                         Price = 42.0f
                     },
                     autoSave: true
                 );

                await _bookVeraionRepository
                    .InsertAsync(new BookVersion()
                    {
                        BookId = book1.Id,
                        Name = "FirstVersion",
                        Description = $" {book1.Name} = version1 is published by Manga"

                    }, autoSave: true);

                await _bookVeraionRepository
                    .InsertAsync(new BookVersion()
                    {
                        BookId = book2.Id,
                        Name = "FirstVersion",
                        Description = $" {book2.Name} = version1 is published by Manga"

                    }, autoSave: true);
            }
        }
    }
}