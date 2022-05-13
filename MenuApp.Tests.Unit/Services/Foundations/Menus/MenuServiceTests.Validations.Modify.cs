// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

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

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ShouldThrowValidationExceptionOnModifyIfMenuIsInvalidAndLogIt(
            string invalidText)
        {
            //given
            var invalidMenu = new Menu
            {
                ItemName = invalidText
            };

            var invalidMenuException = new InvalidMenuException();

            invalidMenuException.AddData(
               key: nameof(Menu.Id),
               values: "Id is required.");

            invalidMenuException.AddData(
               key: nameof(Menu.ItemName),
               values: "ItemName is required.");

            invalidMenuException.AddData(
               key: nameof(Menu.Price),
               values: "Price is required.");

            var expectedMenuValidationException =
                new MenuValidationException(invalidMenuException);

            //when
            Action modifyMenuAction = () => this.menuService.ModifyMenu(invalidMenu);

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
