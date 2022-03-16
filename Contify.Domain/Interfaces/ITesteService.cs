using Contify.Domain.Entities;
using Contify.Domain.SeedWork;

namespace Contify.Domain.Interfaces
{
    public interface ITesteService
    {
        DomainResult<ObjetoTeste> AtualizarObjeto(ObjetoTeste objeto);
    }
}
