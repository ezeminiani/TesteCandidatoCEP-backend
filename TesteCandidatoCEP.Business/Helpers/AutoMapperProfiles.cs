using AutoMapper;
using TesteCandidatoCEP.Domain;
using TesteCandidatoCEP.DTO;

namespace TesteCandidatoCEP.Business.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Endereco, EnderecoDTO>().ReverseMap();
        }
    }
}
