using LibraryProject.Core.Dtos;
using LibraryProject.Core.Requests;
using LibraryProject.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LibraryProject.Web.EndPoints;

public static class MemberEndpoints
{
    public static IEndpointRouteBuilder MapMemberGroup(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGroup("member");
    }

    public static IEndpointRouteBuilder MapMemberEndpoints(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        var memberGroup = endpoints.MapMemberGroup();

        memberGroup.MapGet("", GetAllMembers);
        memberGroup.MapGet("{ID:int}", GetMemberById);
        memberGroup.MapGet("ByType/", GetMembersByType);
        memberGroup.MapPost("Add", AddMember);
        memberGroup.MapPut("{id:int}", UpdateMember);

        return endpoints;
    }

    private static Ok<IEnumerable<MemberDto>> GetAllMembers(MemberServices service)
    {
        return TypedResults.Ok(service.GetAllMembers());
    }

    private static IResult GetMemberById(MemberServices service, int id)
    {
        var member = service.GetMemberById(id);

        return member == null ? TypedResults.NotFound() : TypedResults.Ok(member);
    }

    private static Ok<IEnumerable<MemberDto>> GetMembersByType(MemberServices service, int Id)
    {
        return TypedResults.Ok(service.GetMemberByType(Id));
    }

    public static IResult AddMember(MemberServices service, CreateMemberRequest request)
    {
        var member = service.AddMember(request);
        return member == null ? TypedResults.NotFound() : TypedResults.Ok(member);
    }

    public static IResult UpdateMember(MemberServices service, int id, UpdateMemberRequest request)
    {
        var member = service.UpdateMember(id, request);
        return member == null ? TypedResults.NotFound() : TypedResults.Ok(member);
    }
}