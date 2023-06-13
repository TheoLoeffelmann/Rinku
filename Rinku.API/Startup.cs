

namespace Rinku.API
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using Rinku.DAO;
    using Rinku.Entities;
    using Rinku.Services;

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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rinku API", Version = "v1" });
            });

            services.AddDbContext<RinkuContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("defaultConnection"),
               s => s.CommandTimeout(300)));

            //agregamos la dependencias a bd
            services.AddScoped<CatSalariesDb, CatSalariesDb>();
            services.AddScoped<CatRolesDb, CatRolesDb>();
            services.AddScoped<EmployeesDb, EmployeesDb>();
            services.AddScoped<DeliveriesDb, DeliveriesDb>();
            services.AddScoped<PaymentsDb, PaymentsDb>();

            //agreggamos los servicios
            services.AddScoped<CatSalariesServ, CatSalariesServ>();            
            services.AddScoped<CatRolesServ, CatRolesServ>();
            services.AddScoped<EmployeesServ, EmployeesServ>();
            services.AddScoped<DeliveriesServ, DeliveriesServ>();
            services.AddScoped<PaymentsServ, PaymentsServ>();

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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Rinku Api v1");

            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
