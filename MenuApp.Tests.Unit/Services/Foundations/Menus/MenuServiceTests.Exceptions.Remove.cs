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
        public void ShouldThrowServiceExceptionOnRemoveIfServiceErrorOccursAndLogIt()
        {
            // given
            Menu someMenu = CreateRandomMenu();
            var serviceException = new Exception();

            var failedMenuServiceException =
                new FailedMenuServiceException(serviceException);

            var expectedMenuServiceException =
                new MenuServiceException(
                    failedMenuServiceException);

            this.storageBrokerMock.Setup(broker =>
                broker.DeleteMenu(It.IsAny<Menu>()))
                    .Throws(serviceException);

            // when
            Action removeMenuAction = () => this.menuService.RemoveMenu(someMenu);

            // then
            Assert.Throws<MenuServiceException>(removeMenuAction);

            this.storageBrokerMock.Verify(broker =>
                broker.DeleteMenu(It.IsAny<Menu>()),
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
