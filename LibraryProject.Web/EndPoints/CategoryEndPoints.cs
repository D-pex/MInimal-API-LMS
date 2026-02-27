using LibraryProject.Core.Dtos;
using LibraryProject.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LibraryProject.Web.EndPoints;

public static class CategoryEndpoints
{
    public static IEndpointRouteBuilder MapCategoryGroup(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGroup("Category");
    }

    public static IEndpointRouteBuilder MapCategoryEndpoints(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        var categoryGroup = endpoints.MapCategoryGroup();

        categoryGroup.MapGet("", GetCategory);
        categoryGroup.MapGet("{ID:int}", GetCategoryByID);
      

        return endpoints;
    }

    private static Ok<IEnumerable<CategoryDto>> GetCategory(CategoryServices categoryServices)
    {
        var categories = categoryServices.GetCategoriesList();

        return TypedResults.Ok(categories);
    }

    private static IResult GetCategoryByID(CategoryServices categoryServices, int ID)
    {
        var category = categoryServices.GetCategoryByID(ID);
        return category == null ? TypedResults.NotFound("ID Not Found.") : TypedResults.Ok(category);
    }
}