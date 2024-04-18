using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TorcTest.Api.Request;
using TorcTest.Application.Repository;
using TorcTest.Application.UseCases;
using TorcTest.Application.UseCases.Books;
using TorcTest.Infrastructure.ConfigDB;
using TorcTest.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BooksRequest>());
}


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TestIn, Test>();
builder.Services.AddScoped<IBooksUseCase, BooksUseCase>();
builder.Services.AddScoped<IBookRepository, BooksRepository>();

//setup
var connectionString = (builder.Configuration.GetConnectionString("SqlServerConnection"));
builder.Services.AddDbContext<ApiDbContext>(options =>
options.UseSqlServer(connectionString));

var app = builder.Build();
{

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}





