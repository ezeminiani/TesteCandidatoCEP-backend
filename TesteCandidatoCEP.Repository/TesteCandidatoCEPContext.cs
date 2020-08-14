using Microsoft.EntityFrameworkCore;
using TesteCandidatoCEP.Domain;

namespace TesteCandidatoCEP.Repository
{
    public class TesteCandidatoCEPContext : DbContext
    {
        public TesteCandidatoCEPContext(DbContextOptions<TesteCandidatoCEPContext> options) : base(options)
        {  
        }

        public DbSet<Endereco> Endereco { get; set; }
    }
}
