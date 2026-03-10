using LibraryProject.Core.Dtos;
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
                bookIssuedGroup.MapGet("Search", GetBookIssuedByMemberName);
                return endpoints;
            }
            private static Ok<IEnumerable<BookIssueDto>> GetBookIssue(BookIssueService bookIssuedServices)
            {
                var books = bookIssuedServices.BookIssue();

                return TypedResults.Ok(books);
            } 
            private static IResult GetBookIssuedByMemberName(BookIssueService bookIssuedServices, string member)
            {
                var bookIssue = bookIssuedServices.GetBookIssueBySearch(member);

                return TypedResults.Ok(bookIssue);
            }

        }