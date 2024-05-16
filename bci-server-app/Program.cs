using bci_server_app.Items;
using bci_server_app.ItemsService;
using bci_server_app.Model;
using bci_server_app.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using bci_server_app.MappingProfile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IItemService, ItemService>(); 
builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddDbContext<BciDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAngularOrigins",
            builder =>
            {
                builder.WithOrigins("http://localhost:4200") 
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAngularOrigins");

app.MapGet("getitem", (IItemService service) => {
    return service.GetItems();
});

app.MapPost("additem", (IItemService service, [FromBody] CreateItemDto item) => {
    return service.AddItem(item);
});

app.MapPut("updateitem", (IItemService service, [FromBody] Item item) => {
    return service.UpdateItem(item);
});

app.MapDelete("deleteitem/{id}", (IItemService service, int id) => {
    return service.RemoveItem(id);
});


app.Run();

