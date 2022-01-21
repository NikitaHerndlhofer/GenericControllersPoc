using MinimalGenericApi.DataAccess.Abstractions;

namespace MinimalGenericApi.DataAccess.Models;

public class Book: IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}