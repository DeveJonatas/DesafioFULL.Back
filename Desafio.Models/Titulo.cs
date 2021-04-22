using System.Collections.Generic;

namespace Desafio.Models
{
    public class Titulo
    {
        public long Id { get; set; }

        public long Numero { get; set; }

        public string NomeDevedor { get; set; }

        public string CPFDevedor { get; set; }

        public float Juros { get; set; }

        public float Multa { get; set; }

        public ICollection<Parcela> Parcelas { get; set; } = new List<Parcela>();
    }
}
