using CorePractice_SwaggerRepository.Implement;
using CorePractice_SwaggerRepository.Interface;
using CorePractice_SwaggerService.Implement;
using CorePractice_SwaggerService.Interface;

var builder = WebApplication.CreateBuilder(args);

// HttpClient
builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICovidRepository,CovidRepository>();
builder.Services.AddScoped<ICovidService,CovidService>();

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