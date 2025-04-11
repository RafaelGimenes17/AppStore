using AppStore.Domain.Models.Base;
using AppStore.Domain.Models.Categorias;
using AppStore.Domain.Models.Vendedores;

namespace AppStore.Domain.Models.Produtos;
    public class Produto : EntityBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public Categoria Categoria { get; set; }
        public Vendedor Vendedor { get; set; }
        public Guid CategoriaId { get; set; }
        public Guid VendedorId { get; set; }

}
