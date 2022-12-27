using System.Net;
using Business;
using Business.HttpClients;
using Business.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<MessengerClient>()
    .ConfigureHttpClient(client =>
    {
        client.Timeout = TimeSpan.FromSeconds(15);
    })
    .ConfigurePrimaryHttpMessageHandler(config => new HttpClientHandler
    {
        AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
    });

builder.Services.AddScoped<IFacebookBusiness, FacebookBusiness>();
builder.Services.AddSingleton<IMessengerClient, MessengerClient>();

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