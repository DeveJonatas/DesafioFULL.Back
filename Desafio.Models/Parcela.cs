using System;

namespace Desafio.Models
{
    public class Parcela
    {
        public long Id { get; set; }

        public int NumeroParcela { get; set; }

        public DateTime Vencimento { get; set; }

        public float Valor { get; set; }

        public long IdTitulo { get; set; }

        public Titulo Titulo { get; set; }
    }
}
