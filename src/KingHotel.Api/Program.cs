using FluentValidation.AspNetCore;
using KingHotel.Api.Filters;
using KingHotel.Application.Queries.Users;
using KingHotel.Application.Validators.Users;
using KingHotel.Domain.IService.Auth;
using KingHotel.Infraestructure.Extensions;
using KingHotel.Infraestructure.Services.Auth;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(option => { 
    option.Filters.Add(typeof(ValidationFilters));
}).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>());
builder.Services.AddMvc();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepository();
builder.Services.AddServices();
builder.Services.AddContext(builder.Configuration);

builder.Services.AddMediatR(typeof(GetAllUsersQueryHandler));

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
