using Contify.Application.DTO;
using Contify.Application.SeedWork;
using Contify.Application.ViewModels;

namespace Contify.Application.Interfaces
{
    public interface ITesteAppService
    {
        Result<ObjetoTesteViewModel> Teste(ObjetoTesteDto objetoDto);
    }
}
