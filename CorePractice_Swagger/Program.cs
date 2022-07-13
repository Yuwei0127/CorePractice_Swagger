using System.Reflection;
using CorePractice_SwaggerRepository.Implement;
using CorePractice_SwaggerRepository.Interface;
using CorePractice_SwaggerService.Implement;
using CorePractice_SwaggerService.Interface;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// HttpClient
builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICovidRepository,CovidRepository>();
builder.Services.AddScoped<ICovidService,CovidService>();

// Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    // 設定輸出XML檔案
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();
// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

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