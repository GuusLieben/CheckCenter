using System;
using System.Text;
using CheckCenter.Repositories.EF;
using CheckCenter.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace CheckCenter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication().AddIdentityServerJwt();
            services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
                
            });
            services.AddRazorPages();
            services.AddSpaStaticFiles(configuration => configuration.RootPath = "ClientApp/dist");

            //services.AddControllers();
            services.AddDbContext<ProductionDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Production"), b => b.MigrationsAssembly("Infrastructure")));
            services.AddDbContext<ArchiveDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Archive"), b => b.MigrationsAssembly("Infrastructure")));
            services.AddDbContext<IdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Identity"), b => b.MigrationsAssembly("Infrastructure")));

            services.AddScoped<IEventRepository, EntityFrameworkEventRepository>();
            services.AddScoped<IFinishedEventRepository, EntityFrameworkFinishedEventRepository>();
            services.AddScoped<ICommentRepository, EntityFrameworkCommentRepository>();
            services.AddScoped<IAdditionalInfoRepository, EntityFrameworkAdditionalInfoRepository>();

            services.AddScoped<IActionLogRepository, EntityFrameworkActionLogRepository>();
            services.AddScoped<IFeedbackRepository, EntityFrameworkFeedbackRepository>();

            services.AddScoped<ISourceRepository, EntityFrameworkSourceRepository>();
            services.AddScoped<IStateRepository, EntityFrameworkStateRepository>();
            services.AddScoped<ITypeRepository, EntityFrameworkTypeRepository>();
            services.AddScoped<IIdentityRepository, EntityFrameworkIdentityRepository>();

            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
            services.AddCors();

            services.AddSwaggerGen(c => c.SwaggerDoc("v2", new OpenApiInfo { Title = "CheckCenter complete API", Version = "v2" }));

            //Provide a secret key to Encrypt and Decrypt the Token
            var rsaProvider = new RSACryptoServiceProvider(512);
            var secret = new RsaSecurityKey(rsaProvider);
            
            //Configure JWT Token Authentication
            services.AddAuthentication(auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(token =>
                {
                    token.RequireHttpsMetadata = false;
                    token.SaveToken = true;
                    token.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        //Same Secret key will be used while creating the token
                        IssuerSigningKey = new SymmetricSecurityKey(secret),
                        ValidateIssuer = true,
                        //Usually, this is your application base URL
                        ValidIssuer = "http://localhost:5001/",
                        ValidateAudience = true,
                        //Here, we are creating and using JWT within the same application.
                        //In this case, base URL is fine.
                        //If the JWT is created using a web service, then this would be the consumer URL.
                        ValidAudience = "http://localhost:5001/",
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v2/swagger.json", "CheckCenter API V2"));

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMiddleware<AdminSafeListMiddleware>(Configuration["AdminSafeList"]);
            app.UseRouting();
            if (!env.IsDevelopment()) app.UseSpaStaticFiles();

            //app.UseAuthentication();
            //app.UseIdentityServer();
            //app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    "default",
                    "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment()) spa.UseAngularCliServer("start");
            });

            app.UseCors(builder => builder.WithOrigins("*"));
        }
    }
}
