using System.Reflection;

namespace MinimalGenericApi.GenericControllers;

public static class GenericControllerExtensions
{
    public static TypeInfo[] BuildGenericControllers(this IServiceCollection services, Type baseModelType, params Type[] scanMarkers)
    {
        var modelTypes = new List<Type>();

        foreach (var scanMarker in scanMarkers)
        {
            modelTypes.AddRange(
                scanMarker.Assembly.ExportedTypes
                    .Where(x => baseModelType.IsAssignableFrom(x) && x.IsClass));
        }
        
        return modelTypes
            .Select(et => typeof(GenericController<>).MakeGenericType(et))
            .Select(cct => cct.GetTypeInfo())
            .ToArray();
    }
}