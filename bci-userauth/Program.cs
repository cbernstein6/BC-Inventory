using Microsoft.EntityFrameworkCore;
using bci_userauth.DataContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using bci_userauth.Services;
using bci_userauth.UserModel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserServices, UserServices>();

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowOrigin", builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials();
        });
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.MapPost("add", () => {
    return "Adding User";
});

app.MapPost("login", (IUserServices services, [FromBody] User user) => {
    return services.GetUser(user);
});


app.Run();
