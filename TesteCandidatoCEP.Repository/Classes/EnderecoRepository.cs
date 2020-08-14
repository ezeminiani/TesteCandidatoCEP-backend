using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteCandidatoCEP.Domain;
using TesteCandidatoCEP.Repository.Generic;
using TesteCandidatoCEP.Repository.Interfaces;

namespace TesteCandidatoCEP.Repository.Classes
{
    public class EnderecoRepository : GenericRepository<Endereco>, IEnderecoRepository
    {
        private readonly TesteCandidatoCEPContext ctx;
        public EnderecoRepository(TesteCandidatoCEPContext ctx) : base(ctx)
        {
            this.ctx = ctx;
        }

        public async Task<Endereco> GetCepAsync(string cep, bool asNoTracking = false)
        {
            var dbSet = this.ctx.Endereco;

            if (asNoTracking)
                dbSet.AsNoTracking();

            var query = dbSet.AsQueryable().Where(a => a.Cep == cep);
            var result = await query.Select(s => s).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Endereco>> GetCepsByUFAsync(string uf, bool asNoTracking = false)
        {
            var dbSet = this.ctx.Endereco;

            if (asNoTracking)
                dbSet.AsNoTracking();

            var query = dbSet.AsQueryable().Where(a => a.UF == uf);
            var result = await query.Select(s => s)
                .OrderBy(a => a.UF)
                .ThenBy(a => a.Localidade)
                .ThenBy(a => a.Cep)
                .ToListAsync();

            return result;
        }
    }
}
