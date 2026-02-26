using LibraryProject.Core.Dtos;
using LibraryProject.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LibraryProject.Web.EndPoints;

public static class MemberEndpoints
{
    public static IEndpointRouteBuilder MapMemberGroup(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGroup("Member");
    }

    public static IEndpointRouteBuilder MapMemberEndpoints(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        var memberGroup = endpoints.MapMemberGroup();

        memberGroup.MapGet("", Getmember);
        memberGroup.MapGet("{ID:int}", Getmember);
        memberGroup.MapGet("ByType/{ID:int}", GetMember);

        return endpoints;
    }

    private static Ok<IEnumerable<MemberDto>> Getmember(MemberServices memberServices)
    {
        var Member = memberServices.GetMemberList();
        return TypedResults.Ok(Member);
    }

    private static IResult GetMember(MemberServices memberServices, int ID)
    {
        var Member = memberServices.GetMemberByID(ID);
        return Member == null ? TypedResults.NotFound() : TypedResults.Ok(Member);
    }

    private static IResult GetMemberByType(MemberServices services, int ID)
    {
        var Member = services.GetMemberByType(ID);
        return TypedResults.Ok(Member);
    }
}