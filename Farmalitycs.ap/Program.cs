using Farmalitycs.Infrastructure.Context;
using Farmalitycs.Infrastructure.Repositories;
using Farmalitycs.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<FarmalitycsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IMedicineRepository, MedicineRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();


builder.Services.AddControllers(); 

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); 

app.Run();

