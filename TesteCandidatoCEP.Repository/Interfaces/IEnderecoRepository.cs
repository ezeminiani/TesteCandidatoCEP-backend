using System.Collections.Generic;
using System.Threading.Tasks;
using TesteCandidatoCEP.Domain;
using TesteCandidatoCEP.Repository.Generic;

namespace TesteCandidatoCEP.Repository.Interfaces
{
    public interface IEnderecoRepository : IGenericRepository<Endereco>
    {
        Task<Endereco> GetCepAsync(string cep, bool asNoTracking = false);

        Task<List<Endereco>> GetCepsByUFAsync(string uf, bool asNoTracking = false);
    }
}
