using Microsoft.EntityFrameworkCore;
using ScoreTracker;
using ScoreTracker.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DataContext") ?? throw new InvalidOperationException("Connection string 'DataContext' not found.")
));

builder.Services.AddScoped<IGameManager, GameManager>();
builder.Services.AddScoped<ITeamManager, TeamManager>();
builder.Services.AddScoped<IUserManager, UserManager>();

builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
