using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mission08_Team0208.Data;
using Mission08_Team0208.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();

// Build Db with SQLite
builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TaskConnection")));

// Register Repository
builder.Services.AddScoped<ITaskRepository, EFTaskRepository>();

var app = builder.Build();

// Create/update database and tables from migrations (Development)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TaskDbContext>();
    db.Database.Migrate();
}

// Configure HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();