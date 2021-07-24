using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;
using CrewCore.Helpers;
using CrewCore.Web;
using CrewModel;
using CrewModel.Interface;
using CrewRepository;
using CrewRepository.Interface;
using CrewService;
using CrewService.Interface;
using ITCREWS.Controllers;
using ITCREWS.Models;
using ITCREWS.Models.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.WebEncoders;
using Shared;

namespace ITCREWS
{
    public class Startup
    {
        private static string[] CONFIG_NAMES = new string[] { "SEEDKEY" };

        public Startup(IConfiguration configuration)
        {
        Configuration = configuration;

            if(GCSettings.IsServerGC == false)
            {
                LogHelper.Error($"Not in garbage collector server mode.");
            }
        }

        public IConfiguration Configuration { get; }

        private readonly string itCrewsOrigins = "it-crews";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();

            services.AddCors(o =>
            {
               o.AddPolicy(name: itCrewsOrigins,
                              builder =>
                              {
                                  builder.WithOrigins(new string[] { "http://dev.it-crews.com",
                                                                    "https://dev.it-crews.com",
                                                                    "https://localhost:3000" })
                                  .AllowAnyHeader()
                                  .AllowCredentials()
                                  .AllowAnyMethod();
                              });
            });
            //한글이 인코딩이 되지 않는 문제가 발생할 수도 있기에 추가
            services.Configure<WebEncoderOptions>(o =>
            {
                o.TextEncoderSettings = new System.Text.Encodings.Web.TextEncoderSettings(UnicodeRanges.All);
            });
            services.AddControllers().AddJsonOptions(opt => 
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });


            InitializeDependencyInjection(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(itCrewsOrigins);
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                  name: "Login",
                  pattern: "{controller=Login}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                 name: "Community",
                 pattern: "{controller=Community}/{action=Index}/{id?}");
            });
        }

        private void InitializeDependencyInjection(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ISubjectInfoRepository, SubjectInfoRepository>();
            services.AddTransient<ISubjectFtRepository, SubjecFtRepository>();
            services.AddTransient<ISubjectInfoService, SubjectInfoService>();
            services.AddTransient<IMenuRepository, MenuRepository>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<IReplyRepository, ReplyRepository>();
            services.AddTransient<IReplyService, ReplyService>();
            services.AddTransient<ISignRepository, UserInfoRepository>();
            services.AddTransient<ISignService, SignService>();
            services.AddHttpContextAccessor();
            services.AddSingleton<CookieHelper>();
            services.AddSingleton<CryptoHelper>();
            services.AddSingleton<AppConfig>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //config
            services.AddSingleton((s) =>
            {
                var config = configuration.GetSection("AppConfiguration").Get<AppConfig>();
                foreach (var item in configuration.GetChildren().Where(c => CONFIG_NAMES.Contains(c.Key)).ToDictionary(x => x.Key, x => x.Value))
                {
                    config[item.Key] = item.Value;
                }
                return config;
            });

            var sqlContext = new MySqlDbContext()
            {
                Config = Configuration.GetSection("CommunityDB").Get<DBConfig>()
            };
            services.AddSingleton<IDBContext>(sqlContext);
        }
    }
}
