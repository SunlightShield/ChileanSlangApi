using ChileanSlagApi;
using Firebase.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IO;
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Firebase
builder.Services.Configure<FirebaseConfig>(builder.Configuration.GetSection("Firebase"));
builder.Services.AddScoped<IFirebaseClient>(provider =>
{
    var config = provider.GetService<IOptions<FirebaseConfig>>().Value;
    return new FireSharp.FirebaseClient(new FireSharp.Config.FirebaseConfig
    {
        BasePath = config.BasePath,
        AuthSecret = config.AuthSecret
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();
