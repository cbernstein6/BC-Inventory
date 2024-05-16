using Microsoft.EntityFrameworkCore;
using bci_userauth.DataContext;
using Microsoft.Extensions.DependencyInjection;
using bci_userauth.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserServices, UserServices>();

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("add", () => {
    return "Adding User";
});
app.MapGet("get", (IUserServices services, int id) => {
    return services.GetUser(id);
});


app.Run();
