using ApiPrueba.Model;
using ApiPrueba.Services;
using ApiPrueba.Services.Contabilidad;
using ApiPrueba.Services.Mantenimiento;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace ApiPrueba
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

            services.Configure<BarSettings>(Configuration.GetSection(nameof(BarSettings)));
            services.AddSingleton<IBarSettings>
                (d => d.GetRequiredService<IOptions<BarSettings>>().Value);
            services.AddSingleton<ActivoService>();
            services.AddSingleton<CatalogoActividadService>();
            services.AddSingleton<DetalleActividadService>();
            services.AddSingleton<TipoCuentaService>();
            services.AddSingleton<CuentaService>();
            services.AddSingleton<AsientoService>();
            services.AddSingleton<DetalleAsientoService>();
            services.AddSingleton<UsuarioService>();
            services.AddSingleton<ActividadService>();
            services.AddSingleton<CatalogoService>();
            services.AddSingleton<EmpleadoService>();
            services.AddSingleton<NominaService>();
            services.AddSingleton<RubroService>();
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
