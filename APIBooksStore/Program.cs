using Store.Core.Repositories;
using Store.Data;
using Store.Data.Repsitories;
using Store.Core.Services;
using Store.Service;
using System.Text.Json.Serialization;
using APIBooksStore.Mapping;
using Store.Core.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<ISalerSrevice, SalerService>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<ISalerRepository, SalerRepository>();

builder.Services.AddDbContext<DataContext>();
//builder.Services.AddSingleton<DataContext>();
builder.Services.AddCors(opt => opt.AddPolicy("MyPolicy", policy =>
{
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(ApiMappingProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
