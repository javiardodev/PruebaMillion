using RealEstate.Application.IoC;
using RealEstate.Infrastructure.IoC;
using RealEstate.Api.IoC;
using RealEstate.CrossCutting.Ioc;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilogLogging();

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddCrossCutting()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowCors");
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/api/healthz");
app.Run();