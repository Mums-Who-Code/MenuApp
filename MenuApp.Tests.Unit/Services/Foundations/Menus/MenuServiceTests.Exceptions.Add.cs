using MenuApp.ConsoleApp.Models.Menus;
using MenuApp.ConsoleApp.Models.Menus.Exceptions;
using Moq;
using Xunit;

namespace MenuApp.Tests.Unit.Services.Foundations.Menus
{
    public partial class MenuServiceTests
    {
        [Fact]
        public void ShouldThrowServiceExceptionOnAddIfServiceErrorOccursAndLogIt()
        {
            // given
            Menu inputMenu = CreateRandomMenu();
            var serviceException = new Exception();

            var failedMenuServiceException =
                new FailedMenuServiceException(serviceException);

            var expectedMenuServiceException =
                new MenuServiceException(
                    failedMenuServiceException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertMenu(It.IsAny<Menu>()))
                    .Throws(serviceException);

            // when
            Action addMenuAction = () => this.menuService.AddMenu(inputMenu);

            // then
            Assert.Throws<MenuServiceException>(addMenuAction);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertMenu(It.IsAny<Menu>()),
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
