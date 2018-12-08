using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenText.ProjectApi.Infrastructure;
using Swashbuckle.AspNetCore.Swagger;
using OpenText.ProjectApi.Models;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using OpenText.ProjectApi.Commands;
using OpenText.ProjectApi.Queries;
using System.Threading.Tasks;
using System.Dynamic;

namespace OpenText.ProjectApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddRouting();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Object management Api", Version = "v1" });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //Register with MediatR
            services.AddMediatR(typeof(Startup));          

            //Register custom application dependencies
            services.AddScoped<IObjectRepository, SysObjectRepo>();
            services.AddScoped<IMediator, Mediator>();
            services.AddScoped<IObjectQueries, QueriesServices>();

            //Register our services with Autofac container
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();          

            //Register the command class in Assembly holding the command
            builder.RegisterAssemblyTypes(typeof(SetPropertyCommand).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequest<>));
            builder.RegisterAssemblyTypes(typeof(SetPropertyCommandHandler).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(InsertCommand).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequest<>));
            builder.RegisterAssemblyTypes(typeof(InsertCommandHandler).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));

            var container = builder.Build();

            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
                    SeedDb();            
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Object management Api V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=ObjectSettings}/{action}/{id?}");
            });

            app.UseMvc();
        }

        private static void SeedDb()
        {
            dynamic obj = 1;

            string propertyname = "The Title as PropertyName";
            SysObjectEntity testdata = new SysObjectEntity(obj, propertyname, UniqueId.Next());     
            
           SysObjectRepo.Instance.InsertNewObject(testdata);

            Test instance = new Test("Test Object");
           
            SysObjectRepo.Instance.InsertNewObject(new SysObjectEntity(instance, "This is an object seeded in Db at startup", UniqueId.Next()));
        }
    }

    public class Test
    {
        public string Name { get; set; }
        public Test(string str)
        {
            Name = str;
        }
    }

}


