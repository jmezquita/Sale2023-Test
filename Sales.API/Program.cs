using Microsoft.EntityFrameworkCore;
using Sales.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(cx=> cx.UseSqlServer("name=SaleSqlConection"));
builder.Services.AddTransient<SeedDb>();


var app = builder.Build();
SeedData(app);

void SeedData(WebApplication app) 
{

    IServiceScopeFactory? _serviceScopeFactory = app.Services.GetService<IServiceScopeFactory>();
    using IServiceScope? scope = _serviceScopeFactory!.CreateScope();
    SeedDb? _seedDbServices = scope.ServiceProvider.GetService<SeedDb>();
    _seedDbServices!.SeedAsync().Wait();


}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


//add intruccion to consumer enpoint to blazor proyect
app.UseCors(c => c
.AllowAnyMethod()
.AllowAnyHeader()
.SetIsOriginAllowed(origin => true)
.AllowCredentials());



app.Run();
