using AppStore.Data.Data;
using AppStore.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AppStore.Api.Configuration
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
                PasswordHash = "AQAAAAIAAYagAAAAEJ75mY6XdtZcrA4NaWJNrfyfhRunULkp9GWCA9kkl91fsCDJx57VKmVm4MqqS61uwA==", //123@Teste
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
                new Categoria {Id = 1, Nome = "Livros", Ativo = true },
                new Categoria {Id = 2, Nome = "Cadernos", Ativo = true },
                new Categoria {Id = 3, Nome = "Celulares", Ativo = true }
            });

            await context.SaveChangesAsync();

            if (context.Produtos.Any())
                return;


            await context.Produtos.AddAsync(new Produto()
            {
                Id = 1,
                Nome = "Livro Razor",
                Descricao = "Livro Razor v2",
                Imagem = "cde60271-e316-40b4-b2a2-307062c66d78_Livro Razor.jpg",
                Preco = 100,
                QuantidadeEstoque = 2,
                CategoriaId = 1,
                VendedorId = idUsuario.ToString(),
                Ativo = true
            });

            await context.Produtos.AddAsync(new Produto()
            {
                Id = 2,
                Nome = "Livro Java",
                Descricao = "Livro Java v2",
                Imagem = "40dd4e94-eeac-4f65-9e82-10ba87972601_Livro Java.jpg",
                Preco = 100,
                QuantidadeEstoque = 2,
                CategoriaId = 1,
                VendedorId = idUsuario.ToString(),
                Ativo = true
            });

            await context.Produtos.AddAsync(new Produto()
            {
                Id = 3,
                Nome = "Livro CSS",
                Descricao = "Livro CSS v2",
                Imagem = "72a861c5-1bda-42e6-9a8d-d2ccfdad7c88_Livro CSS.jpg",
                Preco = 100,
                QuantidadeEstoque = 2,
                CategoriaId = 1,
                VendedorId = idUsuario.ToString(),
                Ativo = true
            });

            await context.Produtos.AddAsync(new Produto()
            {
                Id = 4,
                Nome = "Livro C#",
                Descricao = "Livro C# v2",
                Imagem = "1b7f4c39-dc50-4e50-9f1c-4aa6ca70bd2d_Livro C.jpg",
                Preco = 100,
                QuantidadeEstoque = 2,
                CategoriaId = 1,
                VendedorId = idUsuario.ToString(),
                Ativo = true
            });

            await context.Produtos.AddAsync(new Produto()
            {
                Id = 5,
                Nome = "Caderno Brochura",
                Descricao = "Caderno Brochura 96 Folhas",
                Imagem = "d87f92bf-b4da-47c4-a7cb-a4dfdae9a073_Caderno brochura.jpg",
                Preco = 100,
                QuantidadeEstoque = 2,
                CategoriaId = 2,
                VendedorId = idUsuario.ToString(),
                Ativo = true
            });

            await context.Produtos.AddAsync(new Produto()
            {
                Id = 6,
                Nome = "Caderno Desenho",
                Descricao = "Caderno Desenho 100 Folhas",
                Imagem = "e3ed1b27-7ace-451c-9562-747c9dae6fd8_Caderno desenho.jpg",
                Preco = 100,
                QuantidadeEstoque = 2,
                CategoriaId = 2,
                VendedorId = idUsuario.ToString(),
                Ativo = true
            });

            await context.SaveChangesAsync();
        }
    }
}

