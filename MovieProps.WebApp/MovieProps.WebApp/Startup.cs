using Microsoft.EntityFrameworkCore;
using MovieProps.BLL.Contract.Services;
using MovieProps.BLL.Services;
using MovieProps.DAL.Context;
using MovieProps.DAL.Contract.Repository;
using MovieProps.DAL.Repository;
using Swashbuckle.AspNetCore.SwaggerUI;
using Swashbuckle.AspNetCore.Swagger;
using MovieProps.DAL.Contract.UnitOfWork;
using MovieProps.DAL.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using MovieProps.BLL.Mappers;
using Microsoft.Extensions.FileProviders;
using MovieProps.BLL.Contract.Helpers;
using MovieProps.BLL.Helpers;
using MovieProps.Shared.Models;

namespace MovieProps.WebApp
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                });
            });

            services.AddMvc();
            services.AddControllers();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });

            services.AddAuthorization();

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            services.AddSwaggerGen();

            services.AddDbContext<MoviePropsContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:MovieProps"]),
                ServiceLifetime.Scoped);

            var mapperConfig = ConfigureMapping();

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            AddServices(services);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieProps API");
            });

            app.UseRouting();
            app.UseStaticFiles();

            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(env.ContentRootPath, "Images")),
                RequestPath = "/Images",
                EnableDirectoryBrowsing = true
            });

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private MapperConfiguration ConfigureMapping()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ItemProfile());
                mc.AddProfile(new UserProfile());
                mc.AddProfile(new OrderProfile());
            });

            return mapperConfig;
        }

        private void AddServices(IServiceCollection services)
        {
            services.AddTransient<IItemRepository, ItemRepository>();

            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IHttpContextProvider, HttpContextProvider>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<HttpClient, HttpClient>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddScoped<IEmailService, EmailService>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            var emailConfig = Configuration
               .GetSection("EmailConfiguration")
               .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
        }
    }
}
