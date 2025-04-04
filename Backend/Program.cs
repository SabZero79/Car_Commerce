using Backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(80);
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

using(var scope = app.Services.CreateScope())
{
    var context= scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    
    try
    {
        // Only applies migrations, does NOT recreate the DB
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        // Optional: log the error
        Console.WriteLine($"Migration failed: {ex.Message}");
    }

}

app.MapControllers();

app.Run();
