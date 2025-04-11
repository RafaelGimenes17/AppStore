using AppStore.Domain.Models.Base;
using AppStore.Domain.Models.Produtos;

namespace AppStore.Domain.Models.Categorias;

public class Categoria : EntityBase
{
    public required string Codigo { get; set; }
    public required string Nome { get; set; }
    public bool Ativo { get; set; }

    public IEnumerable<Produto> Produtos { get; set; }


}
