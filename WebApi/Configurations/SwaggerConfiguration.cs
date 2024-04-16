using Microsoft.OpenApi.Models;

namespace WebApi.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void RegisterSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Silicon Web Api", Version = "v1" });
                x.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Query,
                    Type = SecuritySchemeType.ApiKey,
                    Name = "key",
                    Description = "Enter API-key"
                });


                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "ApiKey"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });



            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v2", new OpenApiInfo 
                { 
                    Title = "jwtToken_Auth Api", 
                    Version = "v1" 
                });


                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme="Bearer",
                    BearerFormat="JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter access token"
                });


                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
        }
    }
}



/*


using Microsoft.OpenApi.Models;

namespace WebApi.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Silicon Web Api", Version = "v1" });

                // Add security definition for API key
                x.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Query,
                    Type = SecuritySchemeType.ApiKey,
                    Name = "key",
                    Description = "Enter API-key"
                });

                // Add security definition for access token
                x.AddSecurityDefinition("AccessToken", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Query,
                    Type = SecuritySchemeType.ApiKey,
                    Name = "token",
                    Description = "Enter Access Token"
                });

                // Add security requirement for API key
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "ApiKey"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

                // Add security requirement for access token
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "AccessToken"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }
    }
}





 using Microsoft.OpenApi.Models;

namespace WebApi.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Silicon Web Api", Version = "v1" });
                x.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Query,
                    Type = SecuritySchemeType.ApiKey,
                    Name = "key",
                    Description = "Enter API-key"
                });


                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "ApiKey"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }
    }
}*/