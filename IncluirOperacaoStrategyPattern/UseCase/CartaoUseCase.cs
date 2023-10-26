using IncluirOperacaoStrategyPattern.DTOs;
using IncluirOperacaoStrategyPattern.Interfaces;

namespace IncluirOperacaoStrategyPattern.UseCase;

public class CartaoUseCase : IPagamentoUseCaseStrategy
{
    public async Task ProcessaPagamentoAsync(OperacaoRequestDTO operacaoRequestDTO)
    {
        throw new NotImplementedException();
    }
}