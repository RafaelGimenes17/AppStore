using AppStore.Domain.Models.Base;
using AppStore.Domain.Models.Produtos;

namespace AppStore.Domain.Models.Vendedores;

public class Vendedor : EntityBase
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public bool Ativo { get; set; }

    public IEnumerable<Produto> Produtos { get; set; }
}
