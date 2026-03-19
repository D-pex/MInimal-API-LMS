using LibraryProject.Core.Dtos;
using LibraryProject.Core.Requests;
using LibraryProject.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LibraryProject.Web.EndPoints;

public static class BookIssueEndpoints
{
    /*public static IEndpointRouteBuilder MapBookIssueEndpoints( this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        endpoints.MapGet("BookIssue", GetBookIssue);

        return endpoints;
    }

    private static Ok<IEnumerable<BookIssueDto>> GetBookIssue(BookIssueService bookIssueService)
    {
        IEnumerable<BookIssueDto> books = bookIssueService.BookIssue();

        return TypedResults.Ok(books);
    }*/

    public static IEndpointRouteBuilder MapBookIssueGroup(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGroup("BookIssue");
    }

    public static IEndpointRouteBuilder MapBookIssuedEndpoints(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        var bookIssuedGroup = endpoints.MapBookIssueGroup();

        bookIssuedGroup.MapGet("", GetBookIssue);
       // bookIssuedGroup.MapGet("Search", GetBookIssuedByMemberName);
        bookIssuedGroup.MapPost("", CreateBookIssueRequest);
        bookIssuedGroup.MapPatch("{IssueID:int}", UpdateBookIssueRequset);
        return endpoints;
    }

   private static Ok<IEnumerable<BookIssueDto>> GetBookIssue(BookIssueService bookIssueServices, string? memberName)
    {
        var bookIssue = bookIssueServices.BookIssue(memberName);

        return TypedResults.Ok(bookIssue);
    }

    /*private static IResult GetBookIssuedByMemberName(BookIssueService bookIssueServices, string? member)
    {
        var bookIssue = bookIssueServices.GetBookIssueBySearch(member);

        return TypedResults.Ok(bookIssue);
    }*/
    private static IResult CreateBookIssueRequest(BookIssueService bookIssueservice, CreateBookIssueRequest request)
    {
        var result = bookIssueservice.CreateBookIssueRequest(request);
        return result is null
            ? TypedResults.Problem("There was some problem in creating. See log for more info.")
            : TypedResults.Ok(result);
    }
    private static IResult UpdateBookIssueRequset(BookIssueService bookIssueservice, UpdateBookIssueRequset request , int IssueID)
    {
        var result = bookIssueservice.UpdateBookIssueRequset(request, IssueID);
        return result is null
            ? TypedResults.Problem("There was some problem in updating. See log for more info.")
            : TypedResults.Ok(result);
    }
    
    
    
}