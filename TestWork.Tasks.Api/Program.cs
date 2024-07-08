using TestWork.Tasks.Application;
using TestWork.Tasks.Application.Infrastructure.Extensions;
using TestWork.Tasks.Dal.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting();
builder.Services.AddControllers();
builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(ApplicationAssembly).Assembly));

builder.Services.ConfigurePostgresDataAccessServices();
builder.Services.AddApplicationLayerServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();