using Rentfy.Application.Interfaces;
using Rentfy.Application.Mapper;
using Rentfy.Application.Services;
using Rentfy.Data.Configuration;
using Rentfy.Data.Repositories;
using Rentfy.Domain.Entities.Identity;
using Rentfy.Domain.Interfaces;
using Rentfy.Domain.InterfacesRepository;
using Rentfy.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Text;

namespace Rentfy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<RentfyContext>(opt =>
                    opt.UseSqlServer(Configuration.GetConnectionString("RentfyDb"))
            );

            services.AddIdentityCore<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                //options.Password.RequiredLength = 8;
                //options.Password.RequireDigit = true;
                //options.Password.RequireUppercase = true;
                //options.Password.RequireLowercase = true;
                //options.Password.RequiredUniqueChars = 1;
            })
                .AddRoles<Role>()
                .AddRoleManager<RoleManager<Role>>()
                .AddRoleValidator<RoleValidator<Role>>()
                .AddSignInManager<SignInManager<User>>()
                .AddEntityFrameworkStores<RentfyContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            var mapperConfig = new AutoMapperConfig();
            services.AddSingleton(mapperConfig.Mapper);

            services.AddScoped<ITesteAppService, TesteAppService>();
            services.AddTransient<IUserAppService, UserAppService>();
            services.AddTransient<IPhysicalPersonAppService, PhysicalPersonAppService>();
            services.AddTransient<ILegalPersonAppService, LegalPersonAppService>();
            services.AddTransient<IProductCategoryAppService, ProductCategoryAppService>();

            services.AddScoped<ITesteService, TesteService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPhysicalPersonService, PhysicalPersonService>();
            services.AddTransient<ILegalPersonService, LegalPersonService>();
            services.AddTransient<IProductCategoryService, ProductCategoryService>();

            services.AddScoped<IObjetoTesteRepository, ObjetoTesteRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPhysicalPersonRepository, PhysicalPersonRepository>();
            services.AddScoped<ILegalPersonRepository, LegalPersonRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rentfy", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contify v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
