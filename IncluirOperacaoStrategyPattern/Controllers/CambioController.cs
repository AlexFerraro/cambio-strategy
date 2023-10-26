using IncluirOperacaoStrategyPattern.DTOs;
using IncluirOperacaoStrategyPattern.Interfaces;
using IncluirOperacaoStrategyPattern.UseCase;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace IncluirOperacaoStrategyPattern.Controllers;

[ApiController]
[Route("/v1/api/cambio")]
[Produces(Application.Json)]
public sealed class CambioController : ControllerBase
{
    [HttpPost("operacao")]
    [ProducesResponseType(typeof(OperacaoRequestDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> IncluirOperacaoAsync([FromBody] OperacaoRequestDTO request
        , [FromServices] IDictionary<string, IPagamentoUseCaseStrategy> strategy)
    {
        if (!strategy.ContainsKey(request.MeioPagamento))
            return BadRequest("Método de pagamento inválido.");

        IPagamentoUseCaseStrategy pagamentoUseCaseStrategy = strategy[request.MeioPagamento];

        await pagamentoUseCaseStrategy.ProcessaPagamentoAsync(request);

        return Created("", request);
    }

    [HttpPost("operacao/2")]
    [ProducesResponseType(typeof(OperacaoRequestDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> IncluirOperacaoAsync([FromBody] OperacaoRequestDTO request)
    {
        IPagamentoUseCaseStrategy? paymentStrategy = null;

        if (request.MeioPagamento == "especie")
        {
            paymentStrategy = new EspecieUseCase();
        }
        else if (request.MeioPagamento == "cartao")
        {
            paymentStrategy = new CartaoUseCase();
        }
        else if (request.MeioPagamento == "remessa")
        {
            paymentStrategy = new RemessaUseCase();
        }
        else
        {
            return BadRequest("Método de pagamento inválido.");
        }

        await paymentStrategy.ProcessaPagamentoAsync(request);

        return Created("", request);
    }
}