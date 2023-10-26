using IncluirOperacaoStrategyPattern.DTOs;
using IncluirOperacaoStrategyPattern.Interfaces;

namespace IncluirOperacaoStrategyPattern.UseCase;

public class EspecieUseCase : IPagamentoUseCaseStrategy
{
    public async Task ProcessaPagamentoAsync(OperacaoRequestDTO operacaoRequestDTO)
    {
        throw new NotImplementedException();
    }
}