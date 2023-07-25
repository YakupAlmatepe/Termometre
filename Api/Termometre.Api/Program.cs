using Termometre.Api.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddCors(policy => policy.AddDefaultPolicy(builder=> builder.SetIsOriginAllowed(_=>true).AllowAnyHeader().AllowCredentials().AllowAnyMethod().WithExposedHeaders("X-Pagination")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Urls.Add("http://*:5000/");

app.UseCors();
app.UseAuthorization();

app.MapControllers();
app.MapHub<MyHub>("/myhub");

app.Run();
