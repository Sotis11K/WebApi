using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters;

[AttributeUsage(AttributeTargets.All)]

public class UseApiKeyAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var config = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        var apiKey = config.GetValue<string>("ApiKey");
        var accessToken = config.GetValue<string>("Jwt:Secret");



        if (!context.HttpContext.Request.Query.TryGetValue("key", out var providedKey))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        if(!apiKey!.Equals(providedKey))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        await next();

    }


}


