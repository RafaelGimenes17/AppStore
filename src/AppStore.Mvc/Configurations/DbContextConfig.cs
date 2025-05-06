using AppStore.Data.Data;
using AppStore.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AppStore.Mvc.Configurations
{
    public static class DbMigrationHelperExtension
    {
        public static void UseDbMigrationHelper(this WebApplication app)
        {
            DbMigrationHelpers.EnsureSeedData(app).Wait();
        }
    }

    public static class DbMigrationHelpers
    {
        public static async Task EnsureSeedData(WebApplication serviceScope)
        {
            var services = serviceScope.Services.CreateScope().ServiceProvider;
            await EnsureSeedData(services);
        }

        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            await context.Database.MigrateAsync();

            if (env.IsDevelopment() || env.IsEnvironment("Docker") || env.IsStaging())
                await EnsureSeedProducts(context);            
        }

        private static async Task EnsureSeedProducts(AppDbContext context)
        {   
            if (context.Vendedores.Any())
                return;

            var idUsuario = Guid.NewGuid();

            await context.Users.AddAsync(new IdentityUser
            {
                Id = idUsuario.ToString(),
                UserName = "rafael@gmail.com",
                NormalizedUserName = "RAFAEL@GMAIL.COM",
                Email = "rafael@gmail.com",
                NormalizedEmail = "RAFAEL@GMAIL.COM",
                AccessFailedCount = 0,
                LockoutEnabled = false,
                PasswordHash = "AQAAAAIAAYagAAAAEJ206Ya0hdMjTBVizrDcSg1y+iiQ0fXTps2OkEe1xwDYciWWH0FsUoU/SNBPXf8bXQ==",
                TwoFactorEnabled = false,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            });

            await context.Vendedores.AddAsync(new Vendedor()
            {
                Id = idUsuario.ToString(),
                Nome = "Rafael",
                Email = "rafael@gmail.com",
                Ativo = true
            });

            await context.SaveChangesAsync();

            var idCategoria = 1;

            if (context.Categorias.Any())
                return;

            await context.Categorias.AddAsync(new Categoria()
            {   
                //Id = idCategoria,
                Nome = "Caneta",
                Ativo = true
            });

            await context.SaveChangesAsync();

            if (context.Produtos.Any())
                return;

            await context.Produtos.AddAsync(new Produto()
            {
                Nome = "Bic",
                Descricao = "Caneta Bic",
                Imagem = "",
                Preco = 100,
                QuantidadeEstoque = 2,
                CategoriaId = 1,
                VendedorId = idUsuario.ToString(),
            });

            await context.SaveChangesAsync();
        }
    }
}
