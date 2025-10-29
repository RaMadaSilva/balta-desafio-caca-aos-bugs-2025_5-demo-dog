using BugStore.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerDoc();

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddDependecyInjection();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.MapEndpoints();

app.Run();
