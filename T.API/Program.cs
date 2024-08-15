
using T.Persistence.DependencyInjection.Extentions;
using T.Infastructure.DependencyInjection.Extentions;
using Microsoft.Extensions.DependencyInjection;
using T.Core.DependencyInjection.Extentions;
using Microsoft.OpenApi.Models;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;


namespace T.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.OperationFilter<SwaggerFileOperationFilter>();
            });


            // # PERSISTENCE LAYER
            builder.Services.AddSqlServerPersistence(builder.Configuration.GetConnectionString("SqlServerConnection").ToString());

            // # INFASTRUCTURE LAYER
            builder.Services.AddServiceInfastructure(builder.Configuration);

            // # CORE LAYER
            builder.Services.AddDIService();
            builder.Services.AddAutoMapperProfiles();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Title v1");
            //    // Enable support for file uploads
            //    c.EnableFileUploading();
            //});

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
