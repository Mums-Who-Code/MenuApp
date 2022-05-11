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
        public void ShouldThrowDependencyValidationExceptionOnModifyIfValidationErrorOccursAndLogIt()
        {
            //given
            Menu someMenu = CreateRandomMenu();
            var argumentNullException = new ArgumentNullException();

            var nullArgumentMenuException =
                new NullArgumentMenuException(argumentNullException);

            var expectedMenuDependencyValidationException =
                new MenuDependencyValidationException(nullArgumentMenuException);

            this.storageBrokerMock.Setup(broker =>
                broker.UpdateMenu(It.IsAny<Menu>()))
                    .Throws(argumentNullException);

            //when
            Action modifyMenuAction = () => this.menuService.ModifyMenu(someMenu);

            //then
            Assert.Throws<MenuDependencyValidationException>(modifyMenuAction);

            this.storageBrokerMock.Verify(broker =>
                broker.UpdateMenu(It.IsAny<Menu>()),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedMenuDependencyValidationException))),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
