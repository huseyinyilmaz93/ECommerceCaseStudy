using System;
using System.IO;
using System.Reflection;
using ECommerce.Web.CommandPattern;
using ECommerce.Web.CommandPattern.CommandPatternInterfaces;
using ECommerce.Web.Constants;
using ECommerce.Web.DataHolder;
using ECommerce.Web.DataHolder.DataHolderInterfaces;
using ECommerce.Web.Events;
using ECommerce.Web.Events.EventInterfaces;
using ECommerce.Web.FactoryMethod;
using ECommerce.Web.FactoryMethod.FactoryMethodInterfaces;
using ECommerce.Web.Helpers;
using ECommerce.Web.Helpers.HelperInterfaces;
using ECommerce.Web.Repositories;
using ECommerce.Web.Repositories.RepositoryInterfaces;
using ECommerce.Web.Services;
using ECommerce.Web.Services.ServiceInterfaces;
using ECommerce.Web.Validators;
using ECommerce.Web.Validators.ValidatorInterfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ECommerce.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IProductHolder, ProductHolder>();
            services.AddSingleton<IOrderHolder, OrderHolder>();
            services.AddSingleton<ICampaignHolder, CampaignHolder>();

            services.AddSingleton<IProductCreator, ProductCreator>();
            services.AddSingleton<IOrderCreator, OrderCreator>();
            services.AddSingleton<ICampaignCreator, CampaignCreator>();

            services.AddSingleton<IProductReader, ProductReader>();
            services.AddSingleton<ICampaignReader, CampaignReader>();

            services.AddSingleton<IStringifyHelper, StringifyHelper>();
            services.AddSingleton<ICommandParameterHelper, CommandParameterHelper>();
            
            services.AddSingleton<IProductExistanceValidator, ProductExistanceValidator>();
            services.AddSingleton<ICommandParameterValidator, CommandParameterValidator>();
            services.AddSingleton<IProductDoesNotExistValidator, ProductDoesNotExistValidator>();
            services.AddSingleton<ICampaignExistanceForProductValidator, CampaignExistanceForProductValidator>();
            services.AddSingleton<IStockAmountValidator, StockAmountValidator>(); 

            services.AddTransient<ICommand, CreateCampaignCommand>();
            services.AddTransient<ICommand, CreateOrderCommand>();
            services.AddTransient<ICommand, CreateProductCommand>();
            services.AddTransient<ICommand, GetCampaignInfoCommand>();
            services.AddTransient<ICommand, GetProductInfoCommand>();
            services.AddTransient<ICommand, IncreaseTimeCommand>();


            services.AddSingleton<IPriceManipulationEvent, PriceManipulationEvent>();
            services.AddSingleton<ICampaignStatusUpdatorAfterHourTickingEvent, CampaignStatusUpdatorAfterHourTickingEvent>();
            services.AddSingleton<ICampaignUpdatorAfterStockReducementEvent, CampaignUpdatorAfterStockReducementEvent>();

            services.AddSingleton<ICampaignEnderService, CampaignEnderService>();
            services.AddSingleton<IStockAmountReduceService, StockAmountReduceService>();

            services.AddSingleton<ICommandCreator, CommandCreator>();

            services.AddSingleton<ICommandBroker, CommandBroker>();
            services.AddSingleton<ITimer, Timer>();

            services.AddSingleton<IReader, FileReader>();
            services.AddSingleton<ICommandExecuter, CommandExecuter>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(ECommerceConstants.ApiVersion, new OpenApiInfo
                {
                    Title = ECommerceConstants.ScenarioAPI,
                    Version = ECommerceConstants.ApiVersion,
                    Contact = new OpenApiContact()
                    {
                        Name = ECommerceConstants.Author,
                        Url = new Uri(ECommerceConstants.AuthorUrl),
                    },

                });
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Scenario API"); c.RoutePrefix = string.Empty; });

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
