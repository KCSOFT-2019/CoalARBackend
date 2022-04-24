using AR_EduOre_api.Entities;
using AR_EduOre_api.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Design;
using AR_EduOre_api.Services;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddPolicy("AnyOrigin", o => o.WithOrigins("http://s0.z100.vip:7301").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
// Add services to the container.
var tokenSection = builder.Configuration.GetSection("Security:Token");

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(s =>
    {
        s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "请输入token,格式为Bearer xxxx",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });
        s.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                }, new string[]{}
            }
        });
        s.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "文档标题",
            Version = "0.0.1",
            Description = "描述"
                
        });
        var file = Path.Combine(AppContext.BaseDirectory, "AR-EduOre-api.xml");
        var path = Path.Combine(AppContext.BaseDirectory, file);
        //s.IncludeXmlComments(path, true);
        s.OrderActionsBy(o => o.RelativePath);
    }
    
);
builder.Services.AddDbContext<ARDbContext>(option =>
{
    option.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddAuthentication(options => { options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = tokenSection["Issuer"],
            ValidAudience = tokenSection["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSection["Key"])),
            ClockSkew = TimeSpan.Zero
        };
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
//app.UseHttpsRedirection();
app.UseCors("AnyOrigin");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//app.Urls.Add("http://*:5000");

app.Run();


