using TenderApi.Repositories;
using TenderApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Добавление сервисов
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
builder.Services.AddScoped<ITenderService, TenderService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var filePath = Path.Combine(Directory.GetCurrentDirectory(), "TenderExcel.xlsx");
builder.Services.AddScoped<ITenderRepository>(provider => new ExcelTenderRepository(filePath));
builder.Services.AddScoped<ITenderService, TenderService>();

var app = builder.Build();

app.UseCors("AllowAllOrigins"); // Включение CORS

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
