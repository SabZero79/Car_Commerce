using Backend.Data;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("THIS IS SABI’S UPDATED IMAGE");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(8080);
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

using (var scope = app.Services.CreateScope())
{
    Console.WriteLine("Inside CreateScope");

    try
    {
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        Console.WriteLine("Resolved ApplicationDbContext");

        bool carsTableExists = db.Database
            .SqlQueryRaw<int>(@"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Cars'")
            .AsEnumerable()
            .FirstOrDefault() > 0;

        if (carsTableExists)
        {
            Console.WriteLine("The 'Cars' table already exists. Skipping migration.");
        }
        else
        {
            Console.WriteLine("'Cars' table does not exist. Checking for pending migrations...");
            var migrations = db.Database.GetPendingMigrations().ToList();

            if (migrations.Any())
            {
                Console.WriteLine($"Pending migrations:");
                migrations.ForEach(m => Console.WriteLine($" - {m}"));
                db.Database.Migrate();
                Console.WriteLine("Migrations applied successfully.");
            }
            else
            {
                Console.WriteLine("No pending migrations.");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Migration error: {ex.Message}");
        throw;
    }
}


app.MapControllers();

app.Run();
