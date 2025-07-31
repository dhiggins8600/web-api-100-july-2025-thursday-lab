using Marten;

namespace SoftwareCenter.Api.CatalogItems;

public static class Api
{
    public static IEndpointRouteBuilder MapCatalogItems(this IEndpointRouteBuilder app)
    {

        app.MapPost("/vendors/{id:guid}/items", (
            Guid Id, 
            CatalogItemCreateRequest request, 
            IDocumentSession session) =>
        {
            // validate the stuff - see the issue.
            // create the entity

            // from CatalogItemCreateRequest -> CatalogItemEntity
            var entity = request.MapToEntity();
            // save it to the database (side effect)
            // create a response 

            return Results.Ok();
        });
        return app;
    }

    public static IServiceCollection AddCatalogItems(this IServiceCollection services)
    {
       
        //services.AddScoped
        return services;
    }
}

public record CatalogItemCreateRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;

    public  CatalogItemEntity MapToEntity()
    {
        return new CatalogItemEntity
        {

            Id = Guid.NewGuid(),
            Created = DateTimeOffset.UtcNow,
            Description = Description,
            Name = Name,
            Version = Version,
        };
    }
}

public record CatalogItemDetails
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
}

public class CatalogItemEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;

    public DateTimeOffset Created { get; set; }
}