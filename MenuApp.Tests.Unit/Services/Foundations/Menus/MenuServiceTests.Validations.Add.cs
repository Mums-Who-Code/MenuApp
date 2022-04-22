using MenuApp.ConsoleApp.Models.Menus;
using MenuApp.ConsoleApp.Models.Menus.Exceptions;
using Moq;
using Xunit;

namespace MenuApp.Tests.Unit.Services.Foundations.Menus
{
    public partial class MenuServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfMenuIsNullAndLogIt()
        {
            //given
            Menu nullMenu = null;
            var nullMenuException = new NullMenuException();

            var expectedMenuValidationException =
                new MenuValidationException(nullMenuException);

            //when
            Action addMenuAction = () => this.menuService.AddMenu(nullMenu);

            //then
            Assert.Throws<MenuValidationException>(addMenuAction);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedMenuValidationException))),
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertMenu(It.IsAny<Menu>()),
                    Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
