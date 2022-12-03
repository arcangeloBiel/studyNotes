using DevStudyNotes.API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<StudyNoteDbContext>(
    op => op.UseSqlServer(connectString)
    );

builder.Host.ConfigureAppConfiguration((hosting, configureDelegate) => {
    Serilog.Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.MSSqlServer(connectString,
    sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions() {
        AutoCreateSqlTable = true,
        TableName = "Logs"
    })
    .WriteTo.Console()
    .CreateLogger();
}).UseSerilog();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "DevStudyNotes.API",
        Version = "v1",
        Contact = new OpenApiContact {
            Name = "Jakinha dev",
            Email = "Jakinha@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/joao-ribeiro-148a8b140/")
        }
    });

    var xmlFile = "DevStudyNotes.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (true) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();