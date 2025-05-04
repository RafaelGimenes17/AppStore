using AppStore.Data.Data;
using AppStore.Data.Models;
using Microsoft.EntityFrameworkCore;

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
            
            //await context.Database.MigrateAsync();

            //await EnsureSeedProducts(context);
        }

        private static async Task EnsureSeedProducts(AppDbContext context)
        {
            if (context.Categorias.Any())
                return;

            await context.Categorias.AddAsync(new Categoria()
            {   
                Nome = "Canetas",
                Ativo = true
                //Produtos
            });

            await context.SaveChangesAsync();

            if (context.Produtos.Any())
                return;

            await context.Produtos.AddAsync(new Produto()
            {
                Nome = "Caneta Bic",
                Descricao = "Caneta Bic",
                //Imagem
                Preco = 100,
                QuantidadeEstoque = 2,

                //Categoria = 
                //Vendedor
                //CategoriaId
                //VendedorId
            });

            await context.SaveChangesAsync();

        }
    }
}
