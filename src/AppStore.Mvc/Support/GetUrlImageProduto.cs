using AppStore.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppStore.Mvc.support
{
    public static class ImageExtension
    {
        public static string GetPathUrlImagem(this IHtmlHelper html, Produto produto)
        {
            var pathImagens = "/imagens";
            var imageDefault = "img-not-found.jpg";

            if (produto != null && !string.IsNullOrWhiteSpace(produto.Imagem))
            {
                return $"{pathImagens}/{produto.Imagem}";
            }

            return $"{pathImagens}/{imageDefault}";
        }
    }
}
