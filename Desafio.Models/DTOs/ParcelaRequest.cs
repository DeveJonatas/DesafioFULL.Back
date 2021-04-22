using System;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Models.DTOs
{
    public class ParcelaRequest
    {
        [Required]
        public int NumeroParcela { get; set; }

        [Required]
        public DateTime Vencimento { get; set; }

        [Required]
        [Range(0, 9999999999999999.99)]
        public float Valor { get; set; }

    }
}
