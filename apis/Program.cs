using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
options.MapType<DateOnly>(() => new OpenApiSchema
{
    Type = "string",
    Format = "date",
    Example = new OpenApiString("2022-01-01")
})
);
builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy", builder =>
        builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()
    );
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
app.UseCors("Policy");
app.Run();
