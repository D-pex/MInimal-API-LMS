using LibraryProject.Core.Dtos;
using LibraryProject.Persistence;
using LibraryProject.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LibraryProject.Web.EndPoints;

public static class BooksEndpoints
{
    public static IEndpointRouteBuilder MapBooksEndpoints(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        endpoints.MapGet("Books", GetBooks);
        endpoints.MapGet("Books/{ID:int}", GetBook);

        return endpoints;
    }

    private static Ok<IEnumerable<BooksDto>> GetBooks(BooksService booksService)
    {
        var Books = booksService.GetBooksList();

        return TypedResults.Ok(Books);
    }

    private static IResult GetBook(BooksService service, int ID)
    {
        var Books = service.GetBookById(ID);

        return Books == null ? TypedResults.NotFound() : TypedResults.Ok(Books);
    }
}