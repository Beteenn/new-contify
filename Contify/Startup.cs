using Contify.Application.Interfaces;
using Contify.Application.Mapper;
using Contify.Application.Services;
using Contify.Data.Configuration;
using Contify.Data.Repositories;
using Contify.Domain.Entities.Identity;
using Contify.Domain.Interfaces;
using Contify.Domain.InterfacesRepository;
using Contify.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Contify
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
                .AddDbContext<ContifyContext>(opt =>
                    opt.UseSqlServer(Configuration.GetConnectionString("ContifyDb"))
            );

            services.AddIdentity<User, Role>(options =>
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
                .AddEntityFrameworkStores<ContifyContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IObjetoTesteRepository, ObjetoTesteRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            var mapperConfig = new AutoMapperConfig();
            services.AddSingleton(mapperConfig.Mapper);

            services.AddScoped<ITesteAppService, TesteAppService>();
            services.AddScoped<ITesteService, TesteService>();
            services.AddTransient<IUserAppService, UserAppService>();
            services.AddTransient<IUserService, UserService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contify", Version = "v1" });
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
