using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DuAnNho.Areas.Identity.Data;
using DuAnNho.IServices;
using DuAnNho.Models.EF;

using DuAnNho.Services;
using DuAnNho.Models.ViewModel;
using DuAnNho.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationBDContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationBDContextConnection' not found.");

builder.Services.AddDbContext<ApplicationBDContext>(options =>
    options.UseSqlServer(connectionString));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationBDContext>();
// Iservice and Service


builder.Services.AddScoped<IAllServices<CustomerVM>, CustomerServices>();
builder.Services.AddScoped<IAllServices<MaterialsVM>, MaterialServices>();
builder.Services.AddScoped<IAllServices<NewsVM>, NewsServices>();
builder.Services.AddScoped<IAllServices<OrderVM>, OrderServices>();
builder.Services.AddScoped<IAllServices<OrderDetailVM>, OrderDetailServices>();
builder.Services.AddScoped<IAllServices<PaymentMethodsVM>, PayServices>();
builder.Services.AddScoped<IAllServices<PostsVM>, PostsServices>();
builder.Services.AddScoped<IAllServices<ProductVM>, ProductServices>();
builder.Services.AddScoped<IAllServices<ProductCategoryVM>, ProductCategoryServices>();
builder.Services.AddScoped<IAllServices<ProductImageVM>, ProductImageServices>();
builder.Services.AddScoped<IAllServices<SupplierVM>, SupplierServices>();

builder.Services.AddScoped<IAllServices<CategoryVM>, CategoryServicesd>();
builder.Services.AddScoped<IAllServices<UserVM>, UserServices>();

// upload image
builder.Services.AddScoped<IPhotoServices, PhotoServices>();
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllers();

app.Run();
