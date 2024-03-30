using Billpayment.Application;
using Billpayment.Application.Common.Interface;
using Billpayment.Infrastructure;
using Billpayment.Infrastructure.Context;
using Billpayment.Infrastructure.Services;
using Billpayment.Shared.LogService;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Billpayment_flutwave_new
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
            services.AddScoped<IBillpaymentInterface, BillpaymentContext>();

            services.AddDbContext<BillpaymentContext>(opt =>
               opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();

            services.AddScoped<IBillpaymentService, BillpaymentService>();


            services.AddHttpClient();
            services.AddScoped<ILogWritter, LogWriter>();
            services.AddApplication();
            services.AddInfrastructure();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Billpayment", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BluesaltApi v1"));
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
