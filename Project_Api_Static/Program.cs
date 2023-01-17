using CORE;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var TypesToRegister = Assembly.Load("BLL").GetTypes()
               .Where(x => !string.IsNullOrEmpty(x.Namespace))
               .Where(x => x.IsClass).ToList();

var ITypesToRegister = Assembly.Load("BLL").GetTypes()
    .Where(x => !string.IsNullOrEmpty(x.Namespace))
    .Where(x => x.IsInterface).ToList();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MyContext>(options =>
{
    options
        .UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
for (int i = 0; i < TypesToRegister.Count; i++)
{
    var itype = ITypesToRegister.Find(t => (t.Name == "I" + TypesToRegister[i].Name));
    if (itype != null)
    {
        if (itype.Name == "ConsultantServices")
            continue;
        builder.Services.AddScoped(itype, TypesToRegister[i]);
    }

}
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
