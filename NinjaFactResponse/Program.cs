using NinjaFactResponse.Data.Services.Fact;
using NinjaFactResponse.Data.Services.Files;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("ResponseFromExternalAPI", httpClientFactory =>
{
	httpClientFactory.BaseAddress = new Uri("https://catfact.ninja");
});

builder.Services.AddScoped<IFactService, FactService>();
builder.Services.AddScoped<IFileService, FileService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
