using Controle_de_Transporte.Data;
using Controle_de_Transporte.Repository;
using Controle_de_Transporte.Repository.Interface;
using Controle_de_Transporte.Service;
using Controle_de_Transporte.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Controle_de_Transporte
{
    public class Startup
    {       
       
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddDbContext<Context>(options =>
                options.UseSqlServer("MyDatabase"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Thauan .NET CORE",
                    Version = "v1",
                });
            });
            services.AddControllersWithViews();

            // Adicionar serviços customizados
            services.AddScoped<IInstituicaoRepository, InstituicaoRepository>();
            services.AddScoped<IInstituicaoService, InstituicaoService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Thauan .NET CORE v1"));
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
