using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Interfaces;
using Application.Services;
using FluentValidation.AspNetCore;
using Application.Validations;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Auto Mapper Configuration
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Database Configuration
builder.Services.AddDbContext<RebContext>(
    cfg => {
        cfg.UseSqlite("Data Source=test.db", b=>
        b.MigrationsAssembly("Persistence"));
    }
);


//Injections to dependencies
builder.Services.AddTransient<ICategoryService,CategoryService>();
builder.Services.AddTransient<IProductService,ProductService>();
builder.Services.AddTransient<IClientService, ClientService>();
//Controller Configuration
builder.Services.AddControllers().AddFluentValidation(
    cfg => cfg.RegisterValidatorsFromAssemblyContaining<CategoryValidation>()
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Create migration when starting the application
using(var environment = app.Services.CreateScope()){
    var service = environment.ServiceProvider;

    try{
        var context = service.GetRequiredService<RebContext>();
        context.Database.Migrate();
    }catch(Exception e){
        var log = service.GetRequiredService<ILogger<Program>>();
        log.LogError(e, "Error in the migration");
    }


}

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
