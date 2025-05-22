using Microsoft.EntityFrameworkCore;
using Presentation.Data;
using Presentation.Data.Repositories;
using Presentation.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DataContext>(options =>
         options.UseSqlServer(builder.Configuration.GetConnectionString("SqlDbConnection")));
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IAccountProfileService, AccountProfileService>();

var app = builder.Build();
app.MapOpenApi();
app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
