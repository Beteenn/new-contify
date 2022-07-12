using Rentfy.Application.DTO;
using Rentfy.Application.SeedWork;
using Rentfy.Application.ViewModels;
using System.Threading.Tasks;

namespace Rentfy.Application.Interfaces
{
    public interface ILegalPersonAppService
    {
        Task<Result<LegalPersonViewModel>> GetLegalPersonById(long id);
        Task<Result<LegalPersonViewModel>> CreateLegalPerson(LegalPersonDto personDto);
        Task<Result<LegalPersonViewModel>> UpdateLegalPerson(LegalPersonDto personDto);
        Task<Result> DeleteLegalPersonById(long id);
    }
}
