using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Logging;
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
using Microsoft.OpenApi.Models;
using SharpGas.Configuration;
using SharpGas.Encryption;
using SharpGasCore.ConfigurationSettings;
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
 
            StaticConfiguration.PRIVATEXML = settings.PRIVATEXML;

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IOnboardingRepository, OnboardingRepository>();
            services.AddScoped<IGasRepository, GasRepository>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
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
            services
            .AddMvcCore(options =>
            {
                    options.RequireHttpsPermanent = true; // does not affect api requests
                    options.RespectBrowserAcceptHeader = true; // false by default.
                })
            .AddFormatterMappings(); // JSON, or you can build your own custom one (above)
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    "SharpGasOpenAPISpecification",

                    new OpenApiInfo()
                    {
                        Title = "SharpGas API",
                        Version = "1"
                    });

                setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement()
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
                                 In = ParameterLocation.Header,

                         },
                            new List<string>()
                    }
                });


                var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);
                var xmlCoreCommentsFullPath = Path.Combine(settings.SharpGasCorePath, xmlCommentFile);
                setupAction.IncludeXmlComments(xmlCommentsFullPath);
                setupAction.IncludeXmlComments(xmlCoreCommentsFullPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true) // allow any origin
            .AllowCredentials());

            //app.UseMiddleware<EncryptionMiddleWare>();

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseMiddleware<RequestResponseLoggingMiddleware>();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("./swagger/SharpGasOpenAPISpecification/swagger.json", "SharpGas API");
                setupAction.RoutePrefix = "";
            });

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
