using AutoMapper;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TesteCandidatoCEP.Business.Interfaces;
using TesteCandidatoCEP.Domain;
using TesteCandidatoCEP.DTO;
using TesteCandidatoCEP.Repository.Interfaces;

namespace TesteCandidatoCEP.Business.Classes
{
    public class EnderecoBusiness : IEnderecoBusiness
    {
        private readonly IEnderecoRepository repo;
        private readonly IMapper mapper;

        public EnderecoBusiness(IEnderecoRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }


        public async Task<EnderecoDTO> Create(EnderecoDTO enderecoDTO)
        {
            var endereco = this.mapper.Map<Endereco>(enderecoDTO);
            var result = await this.repo.Create(endereco);
            return this.mapper.Map<EnderecoDTO>(result);
        }

        public async Task<EnderecoDTO> GetCepAsync(string cep, bool asNoTracking = false)
        {
            var result = await this.repo.GetCepAsync(cep, asNoTracking);
            return this.mapper.Map<EnderecoDTO>(result);
        }

        public async Task<List<EnderecoDTO>> GetCepsByUFAsync(string uf, bool asNoTracking = false)
        {
            var result = await this.repo.GetCepsByUFAsync(uf, asNoTracking);
            return this.mapper.Map<List<EnderecoDTO>>(result);
        }

        public async Task<EnderecoDTO> Update(EnderecoDTO enderecoDTO)
        {
            var endereco = this.mapper.Map<Endereco>(enderecoDTO);
            var result = await this.repo.Update(endereco);
            return this.mapper.Map<EnderecoDTO>(result);
        }

        public async Task<EnderecoDTO> FindByIdAsync(int id, bool asNoTracking = false)
        {
            var result = await this.repo.FindByIdAsync(id, asNoTracking);
            return this.mapper.Map<EnderecoDTO>(result);
        }

        public async Task<bool> Exists(int? id)
        {
            return await this.repo.Exists(id);
        }

        public async Task<EnderecoDTO> GetCepByWebAsync(string cep)
        {
            string viaCEPUrl = "https://viacep.com.br/ws/" + cep + "/json/";

            using (var client = new WebClient())
            {
                var result = client.DownloadString(viaCEPUrl);

                if (result == null)
                    return null;

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                var jsonRetorno = JsonConvert.DeserializeObject<Endereco>(result, settings);

                // A deserialização não foi bem sucedida (cep nulo) por não existir ou CEP inválido.
                if (jsonRetorno.Cep == null)
                    return null;
              

                // removi a sinal para gravar somente os numeros.
                jsonRetorno.Cep = jsonRetorno.Cep.Replace("-", "");


                // verifica se a localidade já existe no banco de dados;
                // se não existe inclui no banco para futuras consultas;
                // se existe atualiza.
                var localidade = await this.repo.GetCepAsync(jsonRetorno.Cep);

                Endereco endereco;  // endereco que será persistido no banco de dados.

                if (localidade == null)
                    endereco = await this.repo.Create(jsonRetorno);
                else
                {
                    // tive que guardar o ID para atualizar o mesmo registro, o AutoMapper destroi o ID.
                    int idRegistro = localidade.Id;

                    localidade = this.mapper.Map<Endereco>(jsonRetorno);
                    localidade.Id = idRegistro;

                    endereco = await this.repo.Update(localidade);
                }

                return this.mapper.Map<EnderecoDTO>(endereco);

            }

        }
    }

}
