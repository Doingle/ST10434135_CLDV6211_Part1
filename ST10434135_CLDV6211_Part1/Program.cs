using Microsoft.EntityFrameworkCore;
using ST10434135_CLDV6211_Part1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// this connection string Adds DbContext to the container and configures it to use SQL Server with the connection string from appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

#region REFERENCES

//throughout the implementation of this project, I have utilised AI for the structring of classes and assistance with creating various methods. models or views
// I have, to the best of my abilities, reworked any responses to make them my own and referenced where necessary.
// OpenAI (2025). ChatGPT 3.5 LLM. [online] ChatGPT. Available at: https://chatgpt.com/.
//[Accessed 28 March 2025]

‌

#endregion
