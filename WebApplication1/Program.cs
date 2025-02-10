using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<UserDBContext>(context =>
context.UseSqlServer(builder.Configuration.GetConnectionString("connectionDB"))
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Mi API",
        Version = "v1",
        Description = "Una API de ejemplo con ASP.NET Core",
        Contact = new OpenApiContact
        {
            Name = "Tu Nombre",
            Email = "tuemail@example.com",
            Url = new Uri("https://tusitio.com")
        }
    });
});
builder.Services.AddControllers();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    UserDBContext context = scope.ServiceProvider.GetRequiredService<UserDBContext>();
    //context.Database.EnsureCreated();
    context.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
        c.RoutePrefix = string.Empty; // Para que Swagger aparezca en la raíz (http://localhost:5000)
    });
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
