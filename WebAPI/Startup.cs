using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services.DataServices;
using WebAPI.Services.Interface;

namespace WebAPI
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
            services.AddTransient<ICategory, CategoryServices>();
            services.AddTransient<IADS, ADSServices>();
            services.AddTransient<ICMT, CMTServices>();
            services.AddTransient<IFeedback, FeedbackServices>();
            services.AddTransient<IOrder, OrderServices>();
            services.AddTransient<IOder_detail, Order_DetailServices>();
            services.AddTransient<IProduct, ProductServices>();
            services.AddTransient<IProductSize, ProductSizeServices>();
            services.AddTransient<IUser, UserServices>();
            services.AddTransient<INews, NewsServices>();
            services.AddTransient<IRole, RoleServices>();
            services.AddTransient<IWishList, WishListServices>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShopThoiTrangAPI", Version = "v1" });
            });
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                // Return JSON responses in LowerCase?
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            }
           );
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthorization();
            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger ShopThoiTrang v1"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                    
            });
        }
    }
}
