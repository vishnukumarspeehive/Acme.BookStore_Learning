using Acme.BookStore.Repositories;
using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.ObjectMapping;

namespace Acme.BookStore.Books;

public class BooksService : ApplicationService
{
    #region comment
    //https://chatgpt.com/share/d8ccced8-4b34-4b5c-a4af-6602a62c776d
    #endregion
    IBookRepository _bookRepository;
     
    public BooksService(IBookRepository bookRepository)
    {
        this._bookRepository = bookRepository;
    }

    public async Task<List<BookDto>> GetBooksWithVersions()
    {

        try
        {
            //var bookListP=await _bookRepository
            //        .GetBooksWithVersionDetailsAsync(x=>x.Name=="1984");

            var bookEntityList = await _bookRepository.GetBooksWithVersionDetailsAsync();

            var bookDtoList = ObjectMapper.Map<List<Book>, List<BookDto>>(bookEntityList);

            return bookDtoList;
             
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}
