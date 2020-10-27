using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SharpGas.Configuration;
using SharpGas.Encryption;
using SharpGasCore.MidddleWare;
using SharpGasData.Models;
using SharpGasData.Services;

namespace SharpGas
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
            IConfigurationSection settingsSection = Configuration.GetSection("AppSettings");

            AppSettings settings = settingsSection.Get<AppSettings>();
            byte[] signingKey = Encoding.UTF8.GetBytes(settings.EncryptionKey);

            services.AddAuthentication(signingKey, settings.PRIVATEXML);
            services.Configure<AppSettings>(settingsSection);
            services.AddTransient<AuthenticationService>();
            services.AddTransient<UserService>();
            services.AddTransient<TokenServiceAssyMetric>();
            services.AddControllers();
            services.AddDbContextPool<SharpGasContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SharpGasConn")
                    //,  x => x.MigrationsAssembly("SharpGas.Migrations")
                    );
            });
            //services.AddDataProtection().UseCryptographicAlgorithms(new AuthenticatedEncryptionSettings()
            //{
            //    EncryptionAlgorithm = EncryptionAlgorithm.AES_256_GCM,
            //    ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
            //}); 
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IOnboardingRepository, OnboardingRepository>();
            services.AddScoped<IGasRepository, GasRepository>();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme).AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
            {
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.Authority = "https://localhost:44362/";
                options.ClientId = "SharpGasClient";
                options.ResponseType = "code";
                options.UsePkce = false;
                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.SaveTokens = true;
                options.ClientSecret = "secret";
                //options.ClaimActions.DeleteClaim("sid");
                //options.ClaimActions.DeleteClaim("idp");
                //options.ClaimActions.DeleteClaim("s_hash");
                //options.ClaimActions.DeleteClaim("auth_time");
                //options.ClaimActions.MapUniqueJsonKey("role", "role");
                //options.SaveTokens = true;
                //options.ClientSecret = "secret";
                //options.GetClaimsFromUserInfoEndpoint = true;
                //options.TokenValidationParameters = new TokenValidationParameters
                //{
                //    NameClaimType = JwtClaimTypes.GivenName,
                //    RoleClaimType = JwtClaimTypes.Role
                //};
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<EncryptionMiddleWare>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStatusCodePages();
        }
    }
}
