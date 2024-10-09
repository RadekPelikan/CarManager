var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer()
    .AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new()
        {
            Title = "CarManager Customer API", Version = "v1"
        });
    })
    .AddOpenApiDocument()
    .AddSwaggerGen()
    .AddCors(o =>
        o.AddDefaultPolicy(b =>
            b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
    // .AddCors(options =>
    //     options.AddDefaultPolicy(builder =>
    //     {
    //         builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    //         // builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
    //     }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    const string url = "http://localhost";
    const string version = "v1";
    const string endpoint = $"swagger/{version}/swagger.json";
    Dictionary<int, string> services = new Dictionary<int, string>();
    services.Add(5001, "Customer API");
    services.Add(5002, "Order API");
    services.Add(5003, "Vehicle API");
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        {
            foreach (var entry in services)
            {
                c.SwaggerEndpoint(
                    $"{url}:{entry.Key}/{endpoint}",
                    entry.Value
                );
            }
        }
    );
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