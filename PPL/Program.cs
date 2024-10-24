using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.OpenApi.Models;

namespace PPL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PPL", Version = "v1" });
            });

            // Connect to Azure Key Vault
            var secretClient = new SecretClient(new Uri("https://ppl-key.vault.azure.net/"), new DefaultAzureCredential());
            builder.Configuration.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
