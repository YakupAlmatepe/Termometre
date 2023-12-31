using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Termometre.Api.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSignalR();

builder.Services.AddDbContext<ApplicationContext>(options => { options.UseSqlServer("Server=localhost,1433;Database=DbTempreture;User=SA;Password=Ykp14538-;"); });


builder.Services.AddCors(policy => policy.AddDefaultPolicy(builder=> builder.SetIsOriginAllowed(_=>true).AllowAnyHeader().AllowCredentials().AllowAnyMethod().WithExposedHeaders("X-Pagination")));

builder.Services.AddTransient<MyHub>();//<asl�nda mybusiness> kullanmak istedim
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();

app.Urls.Add("http://*:5000/");

app.UseCors();
app.UseAuthorization();

app.MapControllers();
app.UseRouting();
app.MapHub<MyHub>("/myhub");
app.MapHub<MessageHub>("/messagehub");

app.Run();
