using System;

namespace Desafio.Models.DTOs
{
    public class ParcelaResponse
    {
        public int NumeroParcela { get; set; }

        public DateTime Vencimento { get; set; }

        public float ValorOriginal
        {
            get { return (float)Math.Round(valorOriginal, 2); }
            set { valorOriginal = value; }
        }
        private float valorOriginal;

        public float ValorTotal
        {
            get { return (float)Math.Round(valorTotal, 2); ; }
            set { valorTotal = value; }
        }
        private float valorTotal;
    }
}
