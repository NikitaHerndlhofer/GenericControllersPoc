using MinimalGenericApi.DataAccess.Abstractions;

namespace MinimalGenericApi.DataAccess.Models;

public record User : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
}