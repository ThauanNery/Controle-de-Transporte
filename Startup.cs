using Controle_de_Transporte.Data;
using Controle_de_Transporte.Repository;
using Controle_de_Transporte.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Controle_de_Transporte
{
    public class Startup
    {       
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<Context>(options =>
                options.UseSqlServer("MyDatabase"));

            // Adicionar serviços customizados
            services.AddScoped<IInstituicaoRepository, InstituicaoRepository>();
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
