using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PPL.Interfaces;
using PPL.Models;
using PPL.Services;

namespace PPL
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddScoped<ISessionService, SessionService>();

            // Add utilities to the container
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PPL", Version = "v1" });
            });

            // Connect to Azure Key Vault
            var keyVaultUri = new Uri(builder.Configuration["AZURE_VAULT_URI"]!);
            var secretClient = new SecretClient(keyVaultUri, new DefaultAzureCredential());
            builder.Configuration.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());

            // Add database context
            var connectionString = builder.Configuration.GetValue<string>("ppl-database-connection");
            builder.Services.AddDbContext<PplDatabaseContext>(options => options.UseSqlServer(connectionString));

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PPL V1");
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
