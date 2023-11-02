using RazorServices;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContextPool<AppDbContext>(options =>
{
    options.UseMySQL("server = (localdb)\\MSSQLLocalDB; database = lab12; user id = sa; passoword = MyStr0ngPassword!;");
});
builder.Services.AddScoped<IPassengersRepository, SqlPassengersRepository>();
//builder.Services.AddSingleton<IPassengersRepository, MockPassengersRepository>();
builder.Services.AddSingleton<ITrainsRepository,
    MockTrainsRepository>();
builder.Services.AddSingleton<ITicketsRepository,
    MockTicketsRepository>();

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
