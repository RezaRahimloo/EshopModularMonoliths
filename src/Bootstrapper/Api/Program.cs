var builder = WebApplication.CreateBuilder(args);

// Add services the contianer

var app = builder.Build();

// Configure the HTTP request pipeline

app.Run();
