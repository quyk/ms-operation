using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MS.Operation.Application.Extensions;
using System.IO.Compression;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace MS.Operation.API
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
            services.Core();

            services.AddCors(options =>
            {
                options.AddPolicy("PolicyOrigin",
                    builder => builder.WithOrigins("*")
                        .WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS", "HEAD")
                        .AllowAnyHeader()
                );
            });

            services.Configure<GzipCompressionProviderOptions>(options =>
                options.Level = CompressionLevel.Optimal
            );
            services.AddResponseCompression();
            services.AddResponseCaching(options =>
            {
                options.UseCaseSensitivePaths = true;
                options.MaximumBodySize = 1024;
            });

            services.AddSingleton<HtmlEncoder>(
                HtmlEncoder.Create(
                    allowedRanges: new[] {
                        UnicodeRanges.BasicLatin,
                        UnicodeRanges.CjkUnifiedIdeographs
                    }
                )
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("CogtivePolicyOrigin");
            app.UseResponseCaching();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
