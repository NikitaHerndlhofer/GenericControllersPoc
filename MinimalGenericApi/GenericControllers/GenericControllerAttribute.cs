using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace MinimalGenericApi.GenericControllers;

public class GenericControllerAttribute: Attribute, IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        var entityType = controller.ControllerType.GetGenericArguments()[0];
        controller.ControllerName = entityType.Name;
    }
}