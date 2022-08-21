using AutoMapper;
using Rentfy.Application.DTO;
using Rentfy.Application.Interfaces;
using Rentfy.Application.SeedWork;
using Rentfy.Application.ViewModels;
using Rentfy.Domain.Entities;
using Rentfy.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Rentfy.Application.Services
{
    public class RentAppService : BaseAppService, IRentAppService
    {
        private readonly IRentService _rentService;

        public RentAppService(IRentService rentService, IMapper mapper) : base(mapper)
        {
            _rentService = rentService ?? throw new ArgumentNullException(nameof(rentService));
        }

        public async Task<Result<RentViewModel>> GetRentById(long id)
        {
            var rentResult = await _rentService.GetById(id);

            return Mapper.Map<Result<RentViewModel>>(rentResult);
        }

        public async Task<Result<RentViewModel>> CreateRent(RentDto rentDto)
        {
            var rent = new Rent(rentDto.ClientId, rentDto.StoreId, rentDto.StartDate, rentDto.EndDate);

            var rentResult = await _rentService.Create(rent);

            return Mapper.Map<Result<RentViewModel>>(rentResult);
        }

        public async Task<Result> CancelRent(long rentId)
        {
            var updateResult = await _rentService.CancelRent(rentId);

            return Mapper.Map<Result>(updateResult);
        }
    }
}
