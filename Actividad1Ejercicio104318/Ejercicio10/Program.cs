var builder = WebApplication.CreateBuilder(args);

// Habilita compatibilidad de System.Drawing en Windows
AppContext.SetSwitch("System.Drawing.EnableWindowsCompatibility", true);

var app = builder.Build();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



