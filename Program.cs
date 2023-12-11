using Monster_Builder_Web_API.Repositories;
using Monster_Builder_Web_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder =>
        {
            builder.WithOrigins("http://localhost:8000")
                .WithOrigins("http://localhost:9000")
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

//Will use the same Repo for the lifetime of the service. Good for a cache or low memory use service.
builder.Services.AddSingleton<IArmourRepository, ArmourRepository>();

//Will get a new one for each request but reuse it within the request
builder.Services.AddScoped<BeastiaryService>();
//Declared after the services used in its construction are.
//Has a lifetime of the same or less than the services it depends on
builder.Services.AddScoped<ArmouryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

// CORS middleware added after routing and before authorization
app.UseCors("AllowLocalhost");

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
