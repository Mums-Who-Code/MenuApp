using MenuApp.ConsoleApp.Models.Menus;
using MenuApp.ConsoleApp.Models.Menus.Exceptions;
using Moq;
using Xunit;

namespace MenuApp.Tests.Unit.Services.Foundations.Menus
{
    public partial class MenuServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnRetrieveByIdIfIdIsInvalidAndLogIt()
        {
            //given
            var inputMenu = new Menu();
            var invalidMenuException = new InvalidMenuException();

            invalidMenuException.AddData(
                key: nameof(Menu.Id),
                values: "Id is required.");

            var expectedMenuValidationException =
                new MenuValidationException(invalidMenuException);

            //when
            Action retrieveMenuByIdAction = () =>
                this.menuService.RetrieveMenuById(inputMenu.Id);

            //then
            Assert.Throws<MenuValidationException>(retrieveMenuByIdAction);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedMenuValidationException))),
                        Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectMenuById(It.IsAny<int>()),
                    Times.Once);
        }
    }
}
