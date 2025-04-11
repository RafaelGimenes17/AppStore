using AppStore.Domain.Models.Base;

namespace AppStore.Domain.Models.Categorias;

public interface ICategoriaRepository : IRepository<Categoria>
{
    Task<Categoria> ObterCategoriaProduto(Guid id, bool tracking);

    Task<IEnumerable<Categoria>> ObterCategoriasProdutos();
}
