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
        public void ShouldThrowValidationExceptionOnRemoveIfMenuIsNullAndLogIt()
        {
            // given
            Menu nullMenu = null;
            var nullMenuException = new NullMenuException();

            var expectedMenuValidationException =
                new MenuValidationException(nullMenuException);

            // when
            Action removeMenuAction = () => this.menuService.RemoveMenu(nullMenu);

            // then
            Assert.Throws<MenuValidationException>(removeMenuAction);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedMenuValidationException))),
                        Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.DeleteMenu(It.IsAny<Menu>()),
                    Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
