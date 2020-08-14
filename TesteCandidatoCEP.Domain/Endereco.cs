using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteCandidatoCEP.Domain.Base;

namespace TesteCandidatoCEP.Domain
{
    /// <summary>
    /// Classe responsável pela persistencia com o banco de dados.
    /// </summary>
    [Serializable]
    [Table("CEP")]
    public class Endereco : BaseEntity
    {
        [Column("cep", TypeName = "char(9)")]
        [JsonProperty("cep")]
        public string Cep { get; set; }

        
        [Column("logradouro")]
        [MaxLength(500)]
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }


        [Column("complemento")]
        [MaxLength(500)]
        [JsonProperty("complemento")]
        public string Complemento { get; set; }


        [Column("bairro")]
        [MaxLength(500)]
        [JsonProperty("bairro")]
        public string Bairro { get; set; }


        [Column("localidade")]
        [MaxLength(500)]
        [JsonProperty("localidade")]
        public string Localidade { get; set; }


        [Column("uf", TypeName = "char(2)")]
        [MaxLength(2)]
        [JsonProperty("uf")]
        public string UF { get; set; }


        [Column("unidade")]
        [JsonProperty("unidade")]
        public long? Unidade { get; set; }


        [Column("ibge")]
        [JsonProperty("ibge")]
        public int? Ibge { get; set; }


        [Column("gia")]
        [MaxLength(500)]
        [JsonProperty("gia")]
        public string Gia { get; set; }

    }
}
