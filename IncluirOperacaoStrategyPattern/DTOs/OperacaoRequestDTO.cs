namespace IncluirOperacaoStrategyPattern.DTOs;

public record OperacaoRequestDTO
{
    public string MeioPagamento { get; init; } = "especie";
}