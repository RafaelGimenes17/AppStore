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

            if (env.IsDevelopment() || env.IsEnvironment("Docker") || env.IsStaging())
            {
                await context.Database.MigrateAsync();

                await EnsureSeedProducts(context);
            }                          
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
            
            if (context.Categorias.Any())
                return;

            await context.Categorias.AddRangeAsync(new List<Categoria>()
            {
                new Categoria {Id = 1, Nome = "História", Ativo = true },
                new Categoria {Id = 2, Nome = "Informatica", Ativo = true },
                new Categoria {Id = 3, Nome = "Ciência", Ativo = true }
            });

            await context.SaveChangesAsync();

            if (context.Produtos.Any())
                return;

            await context.Produtos.AddAsync(new Produto()
            {
                Nome = "Livro CSS",
                Descricao = "Livro CSS v2",
                Imagem = "",
                Preco = 100,
                QuantidadeEstoque = 2,
                CategoriaId = 1,
                VendedorId = idUsuario.ToString(),
            });

            await context.SaveChangesAsync();

            await context.Produtos.AddAsync(new Produto()
            {
                Nome = "Livro jQuery",
                Descricao = "Livro jQuery v2",
                Imagem = "",
                Preco = 100,
                QuantidadeEstoque = 2,
                CategoriaId = 1,
                VendedorId = idUsuario.ToString(),
            });

            await context.SaveChangesAsync();

            await context.Produtos.AddAsync(new Produto()
            {
                Nome = "Livro HTML",
                Descricao = "Livro HTML v2",
                Imagem = "",
                Preco = 100,
                QuantidadeEstoque = 2,
                CategoriaId = 1,
                VendedorId = idUsuario.ToString(),
            });

            await context.SaveChangesAsync();

            await context.Produtos.AddAsync(new Produto()
            {
                Nome = "Livro Razor",
                Descricao = "Livro Razor v2",
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
