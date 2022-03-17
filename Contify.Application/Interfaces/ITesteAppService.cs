using Contify.Application.DTO;
using Contify.Application.SeedWork;
using Contify.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contify.Application.Interfaces
{
    public interface ITesteAppService
    {
        Task<Result<ObjetoTesteViewModel>> GetById(int id);
        Task<Result<IEnumerable<ObjetoTesteViewModel>>> ListObjects();
        Task<Result<ObjetoTesteViewModel>> AddObject(ObjetoTesteDto objetoDto);
        Task<Result<ObjetoTesteViewModel>> UpdateObject(ObjetoTesteDto objetoDto);
        Task<Result> DeleteById(int id);
    }
}
