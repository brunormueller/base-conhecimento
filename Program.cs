using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using base_conhecimento.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

builder.Services.AddDbContext<banco_conhecimentoContext>(opt => opt.UseSqlServer("Server=localhost\\MSSQLSERVER1;Database=banco_conhecimento;Trusted_Connection=True;TrustServerCertificate=True;User Id=sa;Password=P@ssw0rdsenac;"));
// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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


