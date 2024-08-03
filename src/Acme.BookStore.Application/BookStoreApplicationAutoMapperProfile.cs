using Acme.BookStore.Books;
using Acme.BookStore.BookVersions;
using AutoMapper;

namespace Acme.BookStore;

public class BookStoreApplicationAutoMapperProfile : Profile
{
    public BookStoreApplicationAutoMapperProfile()
    {
        // Mapping from Book to BookDto
        CreateMap<Book, BookDto>()
            .ForMember(dest => dest.BookVersion,
            opt => opt.MapFrom(src => src.BookVersion));

        // Mapping from BookDto to Book
        CreateMap<BookDto, Book>()
            .ForMember(dest => dest.BookVersion, opt => opt.MapFrom(src => src.BookVersion));

        // Mapping from BookVersion to BookVersionDto
        CreateMap<BookVersion, BookVersionDto>();

        // Mapping from BookVersionDto to BookVersion
        CreateMap<BookVersionDto, BookVersion>();


    }
}
