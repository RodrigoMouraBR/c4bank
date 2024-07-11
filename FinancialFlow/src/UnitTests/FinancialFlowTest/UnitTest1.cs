using FinancialFlow.Core.Interfaces;
using FinancialFlow.Domain.Entities;
using FinancialFlow.Domain.Interfaces;
using FinancialFlow.Domain.Services;
using FinancialFlowTest.HumanData;
using Microsoft.Extensions.Logging;
using Moq;

namespace FinancialFlowTest
{
    [Collection("BogusCollections")]
    public class UnitTest1
    {
        readonly ProfileBogusFixture _profileBogusFixture;
        public UnitTest1(ProfileBogusFixture profileBogusFixture) => _profileBogusFixture = profileBogusFixture;


        [Fact(DisplayName = "Adicionar Transaction com sucesso :)")]
        [Trait("Financial Transaction", "Service Mock Tests")]
        public async Task AddFinancialTransactionSuccess()
        {
            //ARRANGE
            var fakeTransaction = _profileBogusFixture.GenerateFinancialTransaction_Valid();

            var repositoryMock = new Mock<IFinancialTransactionRepository>();
            var notifierMock = new Mock<INotifier>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var loggerMock = new Mock<ILogger<FinancialTransactionService>>();

            repositoryMock.Setup(repo => repo.UnitOfWork).Returns(mockUnitOfWork.Object);
            repositoryMock.Setup(repo => repo.AddFinancialTransaction(It.IsAny<FinancialTransaction>())).Returns(Task.CompletedTask);
            var financialPostingService = new FinancialTransactionService(notifierMock.Object, repositoryMock.Object, loggerMock.Object);

            //ACT
            await financialPostingService.AddFinancialTransaction(fakeTransaction);

            //ASSERT
            repositoryMock.Verify(repo => repo.AddFinancialTransaction(fakeTransaction), Times.Once);
            mockUnitOfWork.Verify(uow => uow.Commit(), Times.Once);

        }


        [Fact(DisplayName = "Adicionar Transaction com falha :(")]
        [Trait("Financial Transaction", "Service Mock Tests")]
        public async Task AddFinancialTransactionFail()
        {
            //ARRANGE
            var fakeTransaction = _profileBogusFixture.GenerateFinancialTransaction_Invalid();
            var repositoryMock = new Mock<IFinancialTransactionRepository>();
            var notifierMock = new Mock<INotifier>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var loggerMock = new Mock<ILogger<FinancialTransactionService>>();

            repositoryMock.Setup(repo => repo.UnitOfWork).Returns(mockUnitOfWork.Object);
            repositoryMock.Setup(repo => repo.AddFinancialTransaction(It.IsAny<FinancialTransaction>())).Returns(Task.CompletedTask);
            var financialPostingService = new FinancialTransactionService(notifierMock.Object, repositoryMock.Object, loggerMock.Object);


            //ACT
            await financialPostingService.AddFinancialTransaction(fakeTransaction);


            //ASSERT
            repositoryMock.Verify(repo => repo.AddFinancialTransaction(fakeTransaction), Times.Never);
            mockUnitOfWork.Verify(uow => uow.Commit(), Times.Never);
        }











    }
}