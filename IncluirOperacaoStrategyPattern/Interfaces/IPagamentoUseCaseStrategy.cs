using IncluirOperacaoStrategyPattern.DTOs;

namespace IncluirOperacaoStrategyPattern.Interfaces;

public interface IPagamentoUseCaseStrategy
{
    Task ProcessaPagamentoAsync(OperacaoRequestDTO operacaoRequestDTO);
}