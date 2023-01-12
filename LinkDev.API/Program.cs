using LinkDev.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddDIContainer();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.ConfigureFiles();

if (app.Environment.IsDevelopment())
{
    app.ConfigureSwagger();
}

app.ConfigurePipeLine();
app.Run();