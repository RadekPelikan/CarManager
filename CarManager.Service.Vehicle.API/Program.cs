var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer()
    .AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new()
        {
            Title = "CarManager Vehicle API", Version = "v1"
        });
    })
    .AddSwaggerGen()
    .AddCors(options =>
        options.AddDefaultPolicy(builder =>
        {
            builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
        }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors();

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customers}/{action=Index}/{id?}");

app.Run();