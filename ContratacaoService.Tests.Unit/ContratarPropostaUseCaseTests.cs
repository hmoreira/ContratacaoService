using ContratacaoService.Core.Application.DTOs;
using ContratacaoService.Core.Application.UseCases;
using ContratacaoService.Core.Domain.Entities;
using ContratacaoService.Core.Domain.Enums;
using ContratacaoService.Core.Domain.Exceptions;
using ContratacaoService.Core.Domain.Interfaces.Repositories;
using ContratacaoService.Core.Domain.Interfaces.Services;
using Moq;

public class ContratarPropostaUseCaseTests
{
    private readonly Mock<IContratoRepository> _contratoRepositoryMock;
    private readonly Mock<IPropostaService> _propostaServiceMock;
    private readonly ContratarPropostaUseCase _useCase;

    public ContratarPropostaUseCaseTests()
    {
        _contratoRepositoryMock = new Mock<IContratoRepository>();
        _propostaServiceMock = new Mock<IPropostaService>();
        _useCase = new ContratarPropostaUseCase(_contratoRepositoryMock.Object, _propostaServiceMock.Object);
    }

    [Fact]
    public async Task ExecutarAsync_DeveRetornarContratoDto_QuandoPropostaAprovada()
    {
        // Arrange
        var propostaId = Guid.NewGuid();
        var dataContratacao = DateTime.UtcNow;
        var propostaDto = new PropostaDto { PropostaId = propostaId, Status = StatusPropostaEnum.Aprovada };

        _propostaServiceMock
            .Setup(x => x.ConsultarPropostaAsync(propostaId))
            .ReturnsAsync(propostaDto);

        _contratoRepositoryMock
            .Setup(x => x.AdicionarAsync(It.IsAny<Contrato>()))
            .Returns(Task.CompletedTask);

        var dto = new ContratarPropostaDto(propostaId, dataContratacao);

        // Act
        var result = await _useCase.ExecutarAsync(dto);

        // Assert
        Assert.Equal(propostaId, result.PropostaId);
        Assert.Equal(dataContratacao.Date, result.DataContratacao.Date);
        _contratoRepositoryMock.Verify(x => x.AdicionarAsync(It.IsAny<Contrato>()), Times.Once);
    }

    [Fact]
    public async Task ExecutarAsync_DeveLancarExcecao_QuandoPropostaNaoEncontrada()
    {
        // Arrange
        var propostaId = Guid.NewGuid();
        _propostaServiceMock
            .Setup(x => x.ConsultarPropostaAsync(propostaId))
            .ReturnsAsync((PropostaDto?)null);

        var dto = new ContratarPropostaDto(propostaId, DateTime.UtcNow);

        // Act & Assert
        await Assert.ThrowsAsync<DomainException>(() => _useCase.ExecutarAsync(dto));
    }

    [Fact]
    public async Task ExecutarAsync_DeveLancarExcecao_QuandoPropostaNaoAprovada()
    {
        // Arrange
        var propostaId = Guid.NewGuid();
        var propostaDto = new PropostaDto { PropostaId = propostaId, Status = StatusPropostaEnum.Rejeitada };

        _propostaServiceMock
            .Setup(x => x.ConsultarPropostaAsync(propostaId))
            .ReturnsAsync(propostaDto);

        var dto = new ContratarPropostaDto(propostaId, DateTime.UtcNow);

        // Act & Assert
        await Assert.ThrowsAsync<DomainException>(() => _useCase.ExecutarAsync(dto));
    }
}