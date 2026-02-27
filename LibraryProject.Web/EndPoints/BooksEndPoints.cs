using LibraryProject.Core.Dtos;
using LibraryProject.Core.Requests;
using LibraryProject.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Web.EndPoints;

public static class BooksEndpoints
{
    public static IEndpointRouteBuilder MapBooksEndpoints(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);
        
        endpoints.MapGet("Books", GetBooks);
        endpoints.MapGet("Books/{ID:int}", GetBook);  
        endpoints.MapPost("Books/Category/{categoryID:int}", AddBooks); 
       

        return endpoints;
    }

    private static Ok<IEnumerable<BooksDto>> GetBooks(BooksService booksService)
    {
        var books = booksService.GetBooksList();

        return TypedResults.Ok(books);
    }

    private static IResult GetBook(BooksService service, int ID)
    {
        var books = service.GetBookById(ID);

        return books == null ? TypedResults.NotFound() : TypedResults.Ok(books); 
    }

    public static IResult AddBooks(BooksService booksService, int categoryId,
        [FromBody]CreateBooksRequest createBooksRequest)
    {
        BooksDto? booksDto = booksService.AddBooks( categoryId , createBooksRequest ) ;
        return booksDto is null ? TypedResults.NotFound() : TypedResults.Ok(booksDto);

    }
}