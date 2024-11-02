using FIAP.Pos.Tech.Challenge.Api;
using FIAP.Pos.Tech.Challenge.IoC;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

App.SetAtributesAppFromDll();

// Add services to the container.
builder.Services.AddControllers();

builder.Services.ConfigureModelValidations();

builder.Services.AddSwagger("Web Api C# Sample");

builder.Services.RegisterDependencies(builder.Configuration);

WebApplication app = builder.Build();

app.ConfigureSwagger();

app.ConfigureReDoc();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.AddGlobalErrorHandler();

app.Run();
