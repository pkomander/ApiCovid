using ApiCovid.Dtos;
using ApiCovid.Model;
using AutoMapper;

namespace ApiCovid.Profiles
{
    public class CasoCovidProfile : Profile
    {
        public CasoCovidProfile()
        {
            CreateMap<CreateCasoCovidDto, CasoCovid>();
            CreateMap<CasoCovid, ReadCasoCovidDto>();
            CreateMap<UpdateCasoCovidDto, CasoCovid>();
        }
    }
}
