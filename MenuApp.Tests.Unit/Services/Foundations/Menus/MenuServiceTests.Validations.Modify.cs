using MenuApp.ConsoleApp.Models.Menus;
using MenuApp.ConsoleApp.Models.Menus.Exceptions;
using Moq;
using Xunit;

namespace MenuApp.Tests.Unit.Services.Foundations.Menus
{
    public partial class MenuServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnModifyIfMenuIsNullAndLogIt()
        {
            //given
            Menu nullMenu = null;
            var nullMenuException = new NullMenuException();

            var expectedMenuValidationException =
                new MenuValidationException(nullMenuException);

            //when
            Action modifyMenuAction = () => this.menuService.ModifyMenu(nullMenu);

            //then
            Assert.Throws<MenuValidationException>(modifyMenuAction);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedMenuValidationException))),
                        Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.UpdateMenu(It.IsAny<Menu>()),
                    Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
