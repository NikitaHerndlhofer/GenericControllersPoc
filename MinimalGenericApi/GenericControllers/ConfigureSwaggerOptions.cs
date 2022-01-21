using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MinimalGenericApi.GenericControllers;

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    readonly IApiDescriptionGroupCollectionProvider _provider;

    public ConfigureSwaggerOptions(
        IApiDescriptionGroupCollectionProvider  provider ) => this._provider = provider;

    public void Configure( SwaggerGenOptions options )
    {
        
    }
}
