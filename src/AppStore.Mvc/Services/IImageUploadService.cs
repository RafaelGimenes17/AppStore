using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AppStore.Mvc.Services
{
    public interface IImageUploadService
    {
        public Task<bool> UploadArquivo(ModelStateDictionary modelstate, IFormFile arquivo, string imgPrefixo);
    }
}