using System.Collections.Generic;
using System.Threading.Tasks;
using TesteCandidatoCEP.DTO;

namespace TesteCandidatoCEP.Business.Interfaces
{
    public interface IEnderecoBusiness
    {
        Task<EnderecoDTO> Create(EnderecoDTO enderecoDTO);

        Task<EnderecoDTO> Update(EnderecoDTO enderecoDTO);

        Task<EnderecoDTO> GetCepAsync(string cep, bool asNoTracking = false);

        Task<List<EnderecoDTO>> GetCepsByUFAsync(string uf, bool asNoTracking = false);

        Task<EnderecoDTO> FindByIdAsync(int id, bool asNoTracking = false);

        Task<bool> Exists(int? id);

        Task<EnderecoDTO> GetCepByWebAsync(string cep);
    }
}
