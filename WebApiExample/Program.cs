using Microsoft.EntityFrameworkCore;
using Persistence;
using RI.Novus.Core.Boundaries.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IImmovableRepositoryDummy, ImmovableRepositoryDummy>();
builder.Services.AddScoped<IAseguradoRepositoryDummy, AseguradoRepositoyDummy>();
builder.Services.AddScoped<IExpedientRepositoryDummy, ExpedientRepositoryDummy>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { c.CustomSchemaIds(r => r.FullName); });

builder.Services.AddDbContext<WepsysContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


