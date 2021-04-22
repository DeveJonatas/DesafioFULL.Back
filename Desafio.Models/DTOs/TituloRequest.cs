using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Models.DTOs
{
    public class TituloRequest
    {
        [Required]
        public int Numero { get; set; }

        [Required]
        public string NomeDevedor { get; set; }

        [Required]
        public string CPFDevedor { get; set; }

        [Required]
        [Range(0, 9999999999999999.99)]
        public float Juros { get; set; }

        [Required]
        [Range(0, 9999999999999999.99)]
        public float Multa { get; set; }

        [Required]
        public ICollection<ParcelaRequest> Parcelas { get; set; }
    }
}
