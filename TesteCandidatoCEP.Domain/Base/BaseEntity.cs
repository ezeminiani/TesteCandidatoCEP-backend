using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TesteCandidatoCEP.Domain.Base
{
    /// <summary>
    /// Essa classe colocar contem propriedades que são comuns para todas as entidades, por exemplo o ID do registro.
    /// </summary>
    [DataContract]
    public class BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
