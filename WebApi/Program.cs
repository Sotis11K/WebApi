using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();



builder.Services.AddSwaggerGen();



builder.Services.RegisterSwagger();




builder.Services.RegisterJwt(builder.Configuration);


builder.Services.AddDbContext<ApiContexts>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("WebApi_Database")));
var app = builder.Build();



app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "Silicon Web Api v1"));
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
