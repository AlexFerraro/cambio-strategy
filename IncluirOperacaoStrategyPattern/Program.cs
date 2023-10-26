using IncluirOperacaoStrategyPattern.Interfaces;
using IncluirOperacaoStrategyPattern.UseCase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDictionary<string, IPagamentoUseCaseStrategy>>(provider =>
{
    var strategies = new Dictionary<string, IPagamentoUseCaseStrategy>
    {
        { "especie", new CartaoUseCase() },
        { "cartao", new EspecieUseCase() },
        { "remessa", new RemessaUseCase() }
    };

    return strategies;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
