using BlazorBlog.Core.Interfaces;
using BlazorBlog.Data;
using BlazorBlog.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

/*---- Configure Service Container ----*/
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<InMemoryDataModel>();
builder.Services.AddSingleton<IBlogEntryRepository, BlogEntryInMemoryRepository>();

/*---- Configure Application ----*/
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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();