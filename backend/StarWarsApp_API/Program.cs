using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StarWarsApp_API.Services;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Adding services to the container
builder.Services.AddHttpClient<StarWarsService>(); // Registers StarWarsService along with HttpClient
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:8080") 
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Star Wars API", Version = "v1" });
});

var app = builder.Build();
app.UseCors("MyAllowSpecificOrigins"); // Applies the CORS policy

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); 
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Star Wars API V1");
});

app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS
app.UseAuthorization();
app.MapControllers();

app.Run();
