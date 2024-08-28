using Microsoft.EntityFrameworkCore;
using Stripe;
using StripeWebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Adds support for controllers and views

// Configure Entity Framework with SQL Server
builder.Services.AddDbContext<MvcContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
// Sets up Entity Framework to use SQL Server with the connection string from configuration

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Use a custom error handler and HSTS in production environments
    app.UseExceptionHandler("/Home/Error"); // Redirects to error page on exceptions
    app.UseHsts(); // Enforces HTTPS redirection in production
}

app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS
app.UseStaticFiles(); // Serves static files (like CSS, JavaScript, images)

// Set up Stripe API key
StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];
// Configures Stripe with the API key from the configuration

app.UseRouting(); // Sets up routing
app.UseAuthorization(); // Adds authorization middleware

// Set up default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Payment}/{action=Index}/{id?}");
// Maps requests to controllers with default values for controller (Payment) and action (Index)

app.Run(); // Runs the application
