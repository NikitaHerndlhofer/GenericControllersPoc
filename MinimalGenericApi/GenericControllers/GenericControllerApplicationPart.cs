using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MinimalGenericApi.GenericControllers;

public class GenericControllerApplicationPart : ApplicationPart, IApplicationPartTypeProvider
{
    public GenericControllerApplicationPart(IEnumerable<TypeInfo> typeInfos)
    {
        Types = typeInfos;
    }
    
   
    public override string Name => "GenericController";
    public IEnumerable<TypeInfo> Types { get; }
}