using MyDNA.Services.DatTT;
using MyDNA.SoapAPIServices.DatTT.SoapServices;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IServiceProviders, ServiceProviders>();
builder.Services.AddScoped<IFeedBackRatingDatTTSoapService, FeedBackRatingDatTTSoapService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSoapEndpoint<IFeedBackRatingDatTTSoapService>("/IFeedBackRatingDatTTSoapService.asmx", new SoapEncoderOptions());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
