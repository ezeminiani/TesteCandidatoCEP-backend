using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TesteCandidatoCEP.DTO
{
    /// <summary>
    /// Classe de comunicação do frontend com o backend.
    /// </summary>
    [DataContract]
    public class EnderecoDTO
    {
        [DataMember(Order = 0)]
        public int Id { get; set; }

        [DataMember(Order = 1)]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "campo {0} deve ter 9 caracteres")]
        public string Cep { get; set; }

        [DataMember(Order = 2)]
        [StringLength(500, ErrorMessage = "campo {0} deve ter até 500 caracteres")]
        public string Logradouro { get; set; }

        [DataMember(Order = 3)]
        [StringLength(500, ErrorMessage = "campo {0} deve ter até 500 caracteres")]
        public string Complemento { get; set; }

        [DataMember(Order = 4)]
        [StringLength(500, ErrorMessage = "campo {0} deve ter até 500 caracteres")]
        public string Bairro { get; set; }

        [DataMember(Order = 5)]
        [StringLength(500, ErrorMessage = "campo {0} deve ter até 500 caracteres")]
        public string Localidade { get; set; }

        [DataMember(Order = 6)]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "campo {0} deve ter 2 caracteres")]
        public string UF { get; set; }

        [DataMember(Order = 7)]
        [Range(0, long.MaxValue, ErrorMessage = "campo {0} inválido, utilize somente números.")]
        public long Unidade { get; set; }

        [DataMember(Order = 7)]
        [Range(0, int.MaxValue, ErrorMessage = "campo {0} inválido, utilize somente números.")]
        public int Ibge { get; set; }

        [DataMember(Order = 8)]
        [StringLength(500, ErrorMessage = "campo {0} deve ter até 500 caracteres")]
        public string Gia { get; set; }
    }
}
