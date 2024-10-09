var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer()
    // .AddSwaggerGen(c =>
    // {
    //     c.SwaggerDoc("v1", new()
    //     {
    //         Title = "CarManager Order API", Version = "v1"
    //     });
    // })
    // .AddOpenApiDocument()
    .AddSwaggerGen()
    .AddCors(o =>
        o.AddDefaultPolicy(b =>
            b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    // const string version = "v1";
    // const string endpoint = $"swagger/{version}/swagger.json";
    app.UseSwagger();
    // app.UseSwaggerUI(c =>
    //     {
    //         c.SwaggerEndpoint(
    //             endpoint,
    //             version
    //         );
    //     }
    // );
}

app.UseCors();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customers}/{action=Index}/{id?}");

app.Run();