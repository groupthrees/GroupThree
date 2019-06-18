using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewmaster.Alcohol.IRepository;
using Brewmaster.Alcohol.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Swashbuckle.AspNetCore.Swagger;

namespace Brewmaster.Alcohol.Api
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
            // 注册接口和实现类的映射关系  
            services.AddScoped<ITestRepository, TestRepository>();
            //用户
            services.AddScoped<IUserRepository, UserRepository>();
            //首页商品显示
            services.AddScoped<IGoodsRepository, GoodsRepository>();
            //查询页面
            services.AddScoped<IGoodsAllRepository, GoodsAllRepository>();
            //查询一级商品名称
            services.AddScoped<IGoodsTypeRepository, GoodsTypeRepository>();
            //查询品牌名称
            services.AddScoped<IBrandRepository, BrandRepository>();
            //查询产地名称
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            //商品详情页
            services.AddScoped<IGoodsCollectReposity,GoodscollectReposity>();
            //订单页面
            services.AddScoped<IIndentRepository, IndentRepository>();
            //收藏页面
            services.AddScoped<ICollectionRepository, CollectionRepository>();
            //我的优惠券
            services.AddScoped<ICouponRepository, CouponRepository>();
            //我的购物车
            services.AddScoped<IShopCartRepository, ShopCartRepository>();
            //收货地址
            services.AddScoped<IAddressRepository, AddressRepository>();
            //香型
            services.AddScoped<IAromaRepository, AromaRepository>();
            //价位
            services.AddScoped<IValenceRepository, ValenceRepository>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });



            //自动生成 设置MVC 兼容性版本
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //注册跨域服务，允许所有来源
            services.AddCors(options =>
                options.AddPolicy("AllowAnyCors",
                p => p.WithOrigins().AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().AllowCredentials())
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //允许跨域访问
            app.UseCors("AllowAnyCors");
           
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=User}/{action=Resigt}/{id?}");
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });




        }
    }
}
