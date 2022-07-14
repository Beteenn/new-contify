using AutoMapper;
using Rentfy.Application.DTO;
using Rentfy.Application.Interfaces;
using Rentfy.Application.SeedWork;
using Rentfy.Application.ViewModels;
using Rentfy.Domain.Entities;
using Rentfy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentfy.Application.Services
{
    public class StoreAppService : BaseAppService, IStoreAppService
    {
        private readonly IStoreService _storeService;

        public StoreAppService(IStoreService storeService, IMapper mapper) : base(mapper)
        {
            _storeService = storeService ?? throw new ArgumentNullException(nameof(storeService));
        }

        public async Task<Result<StoreViewModel>> GetStoreById(long id)
        {
            var storeResult = await _storeService.GetById(id);

            return Mapper.Map<Result<StoreViewModel>>(storeResult);
        }

        public async Task<Result<StoreViewModel>> CreateStore(StoreDto storeDto)
        {
            var storeUpdate = new Store(storeDto.LegalPersonId);

            var storeResult = await _storeService.Create(storeUpdate);

            return Mapper.Map<Result<StoreViewModel>>(storeResult);
        }

        public async Task<Result<StoreViewModel>> UpdateStore(StoreDto storeDto)
        {
            var storeUpdate = new Store(storeDto.LegalPersonId);

            var storeResult = await _storeService.Update(storeDto.Id, storeUpdate);

            return Mapper.Map<Result<StoreViewModel>>(storeResult);
        }

        public async Task<Result> DeleteStoreById(long id)
        {
            var result = await _storeService.DeleteById(id);

            return Mapper.Map<Result>(result);
        }
    }
}
