using FrontEnd.Services;

var builder = WebApplication.CreateBuilder(args);

// Determine backend URL from environment or default to 'http://backend'
var backendUrl = Environment.GetEnvironmentVariable("BACKEND_URL") ?? "http://backend";

builder.Services.AddHttpClient<CarService>(client =>
{
    client.BaseAddress = new Uri(backendUrl);
    client.Timeout = TimeSpan.FromSeconds(30);
});


builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(8080);
});
// Add services to the container.
builder.Services.AddHttpClient<CarService>(client =>
{
    client.BaseAddress = new Uri("http://backend:8080"); // internal Docker DNS
});
builder.Services.AddRazorPages();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
