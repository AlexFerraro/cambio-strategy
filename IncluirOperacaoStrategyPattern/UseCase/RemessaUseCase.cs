using IncluirOperacaoStrategyPattern.DTOs;
using IncluirOperacaoStrategyPattern.Interfaces;

namespace IncluirOperacaoStrategyPattern.UseCase;

public class RemessaUseCase : IPagamentoUseCaseStrategy
{
    public async Task ProcessaPagamentoAsync(OperacaoRequestDTO operacaoRequestDTO)
    {
        throw new NotImplementedException();
    }
}