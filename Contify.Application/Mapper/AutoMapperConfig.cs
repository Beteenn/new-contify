using AutoMapper;
using System;

namespace Contify.Application.Mapper
{
    public class AutoMapperConfig
    {
        private IMapper _mapper;

        public AutoMapperConfig()
        {
            try
            {
                var mapperConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new DomainToViewModelProfile());
                });

                _mapper = mapperConfig.CreateMapper();
            }
            catch (Exception ex)
            {
                throw new Exception("Automapper: ", ex);
            }
        }

        public IMapper Mapper => _mapper;
    }
}
