using AppStore.Data.Contexts;
using AppStore.Domain.Models.Vendedores;

namespace AppStore.Data.Repositories;

public class VendedorRepository : Repository<Vendedor>, IVendedorRepository
{
    public VendedorRepository(AppDbContext context) : base(context)
    {
    }
}
