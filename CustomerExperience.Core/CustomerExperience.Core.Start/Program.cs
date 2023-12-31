using Application.Commands.Users.CreateUser;
using CustomerExperience.Core.Application;
using CustomerExperience.Core.Application.Commands.CreateUser;
using CustomerExperience.Core.Application.DTO;
using CustomerExperience.Core.Domain.RoleAggregate;
using CustomerExperience.Core.Infra;
using CustomerExperience.Core.Infra.Repositories;
//using CustomerExperience.Core.Infra.Services;
using Mapster;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

//builder.Services.AddSingleton<UserAddedConsumer>();

//builder.Services.AddSingleton<ProducerService>();

builder.Services.AddMapster();

var config = TypeAdapterConfig.GlobalSettings;

config.Scan(Assembly.GetExecutingAssembly());

builder.Services.AddSingleton(config);


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));

builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
   .AddJwtBearer(options =>
   {
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
       };
   });


builder.Services.AddCors(corsOptions =>
{
    corsOptions.AddPolicy("policy",
    builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});


builder.Services.AddLogging(configure =>
{
    configure.AddSerilog(new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.Console()
        .CreateLogger());
});


builder.Host
    .UseMassTransit((hostContext, x) =>
    {

        var kafkaBrokerServer = builder.Configuration["MessageBroker:Host"];
        x.UsingInMemory((context, cfg) => { cfg.ConfigureEndpoints(context); });

        x.AddRider(r =>
        {
            x.AddConsumer<UserAddedConsumer>();
          

            var topicName = "UserCreated";

            r.AddProducer<string, CreateUserCommand>(topicName, (context, cfg) =>
            {
            });

          
            r.UsingKafka((context, cfg) =>
            {
                cfg.Host(kafkaBrokerServer);
            });

        });
    });


//builder.Services.AddMassTransit(x =>
//{
//    var kafkaBrokerServer = "localhost:9092";
//    x.UsingInMemory((context, cfg) => { cfg.ConfigureEndpoints(context); });

//    x.AddConsumer<UserAddedConsumer>();


//    x.AddRider(rider =>
//    {
//        rider.UsingKafka((context, k) =>
//        {

//            k.Host(kafkaBrokerServer);


//        });
//    });


//});


//builder.Services.AddMassTransitHostedService();









var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("policy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
