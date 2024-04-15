using Controle_de_Transporte.Data;
using Controle_de_Transporte.Repository.Interface;
using Controle_de_Transporte.Repository;
using Controle_de_Transporte.Service.Interface;
using Controle_de_Transporte.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;

namespace Controle_de_Transporte
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder
                .ConfigureServices((context, services) =>
                {
                    // Obtenha a string de conexão do arquivo appsettings.json
                    var connectionString = context.Configuration.GetConnectionString("MyDatabase");

                    // Configure o contexto do banco de dados com a string de conexão
                    services.AddDbContext<Context>(options =>
                        options.UseSqlServer(connectionString));

                    // Outros serviços
                    services.AddCors(options =>
                    {
                        options.AddPolicy("AllowSwagger",
                            builder =>
                            {
                                builder.AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader();
                            });
                    });
                    services.AddSwaggerGen(c =>
                    {
                        c.SwaggerDoc("v1", new OpenApiInfo
                        {
                            Title = "Thauan .NET CORE",
                            Version = "v1",
                        });
                    });
                    // Configure outros serviços
                    services.AddControllersWithViews();

                    services.AddScoped<IInstituicaoRepository, InstituicaoRepository>();
                    services.AddTransient<IInstituicaoService, InstituicaoService>();
                })
                .Configure((app) =>
                {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");
                    });
                    app.UseHttpsRedirection();
                    app.UseStaticFiles();
                    app.UseRouting();
                    app.UseAuthentication();
                    app.UseAuthorization();
                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Home}/{action=Index}/{id?}");
                    });
                });
        });

    }
}

