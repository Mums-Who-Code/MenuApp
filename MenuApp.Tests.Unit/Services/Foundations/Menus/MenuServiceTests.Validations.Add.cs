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

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task ShouldThrowValidationExceptionOnAddIfMenuIsInvalidAndLogIt(
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
            Action addMenuAction = () => this.menuService.AddMenu(invalidMenu);

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
