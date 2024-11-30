using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Api;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.IoC;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

App.SetAtributesAppFromDll();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.ConfigureModelValidations();
builder.Services.AddSwagger("Web Api C# Sample");

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDb"));

builder.Services.RegisterDependencies(builder.Configuration);

WebApplication app = builder.Build();

app.ConfigureSwagger();

app.ConfigureReDoc();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.AddGlobalErrorHandler();

app.Run();
