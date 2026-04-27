using Microsoft.AspNetCore.ResponseCompression;
using PharmacyApi.Data.Implementations;
using PharmacyApi.Data.Interfaces;
using PharmacyApi.Infrastructures.Implementations;
using PharmacyApi.Infrastructures.Interfaces;
using PharmacyApi.Middlewares;
using System.IO.Compression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Cors policy
builder.Services.AddCors(options =>
 {
     options.AddPolicy("CORSPolicy", policy =>
     {
         policy.WithOrigins(["http://localhost:4200", "http://localhost:5173"])
             .AllowAnyMethod()
             .AllowAnyHeader()
             .AllowCredentials();
     });
 });

// compression techniques
builder.Services.AddResponseCompression(options =>
{
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        ["application/json", "text/plain"]);
});

builder.Services.Configure<BrotliCompressionProviderOptions>(options =>
{
    options.Level = CompressionLevel.Fastest;
});

builder.Services.Configure<GzipCompressionProviderOptions>(options =>
{
    options.Level = CompressionLevel.SmallestSize;
});


// Add memeory cache
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IMedicineData, MedicineData>();
builder.Services.AddScoped<IMedicineService, MedicineService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseMiddleware<RequestAuditMiddleware>();
app.UseCors("CORSPolicy");
app.UseResponseCompression();
app.UseAuthorization();

app.MapControllers();

app.Run();
