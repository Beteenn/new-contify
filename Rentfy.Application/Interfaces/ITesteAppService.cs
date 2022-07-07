using Rentfy.Application.DTO;
using Rentfy.Application.SeedWork;
using Rentfy.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentfy.Application.Interfaces
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
