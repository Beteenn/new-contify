using Rentfy.Application.DTO;
using Rentfy.Application.SeedWork;
using Rentfy.Application.ViewModels;
using System.Threading.Tasks;

namespace Rentfy.Application.Interfaces
{
    public interface IPhysicalPersonAppService
    {
        Task<Result<PhysicalPersonViewModel>> CreatePhysicalPerson(PhysicalPersonDto personDto);
    }
}
