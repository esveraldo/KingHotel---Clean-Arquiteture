using KingHotel.Application.Queries.Users;
using KingHotel.Infraestructure.Extensions;
using MediatR;
using FluentValidation.AspNetCore;
using KingHotel.Application.Validators.Users;
using KingHotel.Api.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
builder.Services.AddControllers(option => option.Filters.Add(typeof(ValidationFilters)))
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>());
builder.Services.AddMvc();
//builder.Services.AddMvc().AddJsonOptions(o =>
//{
//    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
//});
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
