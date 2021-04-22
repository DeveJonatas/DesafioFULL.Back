using AutoMapper;
using Desafio.BLL.Infra;
using Desafio.BLL.Infra.Infra;
using Desafio.Models;
using Desafio.Models.DTOs;
using Desafio.Repository.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.BLL
{
    public class TituloBLL : ITituloBLL
    {
        private readonly ITituloRepository _repository;
        private readonly IMapper _mapper;

        public TituloBLL(ITituloRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TituloResponse>> GetAllAsync()
        {
            var rtn = new List<TituloResponse>();

            var list = await _repository.GetAllAsync();

            foreach (var titulo in list)
            {
                var parcelas = new List<ParcelaResponse>();

                foreach (var parcela in titulo.Parcelas)
                {
                    var p = new ParcelaResponse()
                    {
                        NumeroParcela = parcela.NumeroParcela,
                        Vencimento = parcela.Vencimento,
                        ValorOriginal = parcela.Valor,
                        ValorTotal = calculaJuros(parcela.Vencimento, parcela.Valor, titulo.Juros) + parcela.Valor
                    };

                    parcelas.Add(p);
                }

                var t = new TituloResponse()
                {
                    Id = titulo.Id,
                    CPFDevedor = titulo.CPFDevedor,
                    Juros = titulo.Juros,
                    Multa = titulo.Multa,
                    NomeDevedor = titulo.NomeDevedor,
                    NumeroTitulo = titulo.Numero,
                    DiasAtraso = calculaAtraso(parcelas.Min(x => x.Vencimento)),
                    Parcelas = parcelas,
                    ValorOriginal = parcelas.Sum(x => x.ValorOriginal),
                    ValorTotal = parcelas.Sum(x => x.ValorTotal) + (calculaAtraso(parcelas.Min(x => x.Vencimento)) > 0 ? (titulo.Multa / 100) * parcelas.Sum(x => x.ValorOriginal) : 0.0f)
                };

                rtn.Add(t);
            }

            return rtn;
        }

        public Task<long> AddAsync(TituloRequest model)
        {
            if (model.Parcelas.Count == 0)
            {
                throw new BusinessException("Parcelas não informadas.");
            }

            return _repository.Add(_mapper.Map<Titulo>(model));
        }

        float calculaJuros(DateTime vencimento, float valor, float juros)
        {
            int diasAtraso = calculaAtraso(vencimento);

            if (diasAtraso > 0)
            {
                return (juros / 3000) * diasAtraso * valor;
            }

            return 0.0f;
        }

        int calculaAtraso(DateTime vencimento)
        {
            int diasAtraso = DateTime.Now.Subtract(vencimento).Days;

            if (diasAtraso > 0)
            {
                return diasAtraso;
            }

            return 0;
        }

    }
}
