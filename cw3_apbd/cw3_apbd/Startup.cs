using cw3_apbd.Handlers;
using cw3_apbd.Middleware;
using cw3_apbd.Models_cw10;
using cw3_apbd.Service;
using cw3_apbd.Tools;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace cw3_apbd
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
            services.AddDbContext<s17651Context>(options => 
            {
                options.UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s17651;Integrated Security=True");
            });
            services.AddScoped<IDbStudent, DbStudent>();
            //services.AddScoped<IStudentsDBService, SqlServerDbService>();
            services.AddScoped<IStudentsDBService, EFSqlServerDbService>();
            services.AddScoped<IRequestLogService, FileLoggerService>();

            //Authetication HTTP Basic (cw7 zad1)
            //services.AddAuthentication("AuthenticationBasic")
            //        .AddScheme<AuthenticationSchemeOptions, BasicAuthHandler>("AuthenticationBasic", null);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidIssuer = "s17651",
                            ValidAudience = "Students",
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"]))
                        };
                    });

            services.AddControllers()
                    .AddXmlSerializerFormatters();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IStudentsDBService service)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //logowanie zapytañ
            app.UseMiddleware<RequestLogger>();

            //sprawdzenie, czy Request zawiera nag³ówek Index
            app.Use(async (context, next) =>
            {
                //je¿eli brak to wychodzimy
                if (!context.Request.Headers.ContainsKey("Index"))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Wymagane jest podanie numeru indeksu!");
                    return;
                }
                //je¿eli jset to pobieramy nr indeksu
                string indexNumber = context.Request.Headers["Index"].ToString();
                if (!IndexValidator.validate(indexNumber))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Incorrect index number (sxxxxx)!");
                    return;
                }
                //pobieramy studenta
                var student = service.GetStudent(indexNumber);
                if (student == null) 
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync("Couldn't find student with indexNumber: " + indexNumber);
                    return;
                }
                await next();
            });

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
