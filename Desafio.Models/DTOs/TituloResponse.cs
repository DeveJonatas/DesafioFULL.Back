using System;
using System.Collections.Generic;

namespace Desafio.Models.DTOs
{
    public class TituloResponse
    {
        public long Id { get; set; }

        public long NumeroTitulo { get; set; }

        public string NomeDevedor { get; set; }

        public string CPFDevedor { get; set; }

        public float Juros
        {
            get { return (float)Math.Round(juros, 2); }
            set { juros = value; }
        }
        private float juros;

        public float Multa
        {
            get { return (float)Math.Round(multa, 2); }
            set { multa = value; }
        }
        private float multa;

        public int DiasAtraso { get; set; }

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

        public ICollection<ParcelaResponse> Parcelas { get; set; }
    }
}
