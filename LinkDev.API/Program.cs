using LinkDev.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddDIContainer();

var app = builder.Build();


app.ConfigureFiles();

if (app.Environment.IsDevelopment())
{
    app.ConfigureSwagger();
}

app.ConfigurePipeLine();
app.Run();