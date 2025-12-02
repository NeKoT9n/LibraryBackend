using Library.Application.Services;
using Library.DataAccess.Repositories;
using Library.Domain.Abstractions;
using Library.DataAccess;
using Microsoft.EntityFrameworkCore;
using Library.Domain.Factory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BooksDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(BooksDbContext)));
});

builder.Services.AddScoped<IBookFactory, BookFactory>();
builder.Services.AddScoped<ILibraryService, LibraryService>();
builder.Services.AddScoped<IBooksRepository, BooksRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
