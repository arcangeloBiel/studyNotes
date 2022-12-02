using DevStudyNotes.API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectString = builder.Configuration.GetConnectionString("DevStudyNotes");
builder.Services.AddDbContext<StudyNoteDbContext>(
    op => op.UseSqlServer(connectString)
    );


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    //c.SwaggerDoc("docs-v1", new OpenApiInfo {
    //    Title = "DevStudyNotes",
    //    Version = "v1",
    //    Contact = new OpenApiContact {
    //        Name = "Jakinha dev",
    //        Email = "Jakinha@gmail.com",
    //        Url = new Uri("Linkedin")
    //    }
    //});

    var xmlFile = "DevStudyNotes.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();