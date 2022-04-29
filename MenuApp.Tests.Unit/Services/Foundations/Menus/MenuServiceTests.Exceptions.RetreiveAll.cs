using MenuApp.ConsoleApp.Models.Menus.Exceptions;
using Moq;
using Xunit;

namespace MenuApp.Tests.Unit.Services.Foundations.Menus
{
    public partial class MenuServiceTests
    {
        [Fact]
        public void ShouldThrowServiceExceptionOnRetrieveAllIfServiceErrorOccursAndLogIt()
        {
            //given
            var serviceException = new Exception();

            var failedMenuServiceException =
                new FailedMenuServiceException(serviceException);

            var expectedMenuServiceException =
                new MenuServiceException(failedMenuServiceException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllMenus())
                    .Throws(serviceException);

            //when
            Action retrieveAllAction = () => this.menuService.RetrieveAllMenus();

            //then
            Assert.Throws<MenuServiceException>(retrieveAllAction);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllMenus(),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedMenuServiceException))),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
