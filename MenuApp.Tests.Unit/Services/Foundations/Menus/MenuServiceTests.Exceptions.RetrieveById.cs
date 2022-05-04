// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using MenuApp.ConsoleApp.Models.Menus.Exceptions;
using Moq;
using Xunit;

namespace MenuApp.Tests.Unit.Services.Foundations.Menus
{
    public partial class MenuServiceTests
    {
        [Fact]
        public void ShouldThrowDependencyValidationExceptionOnRetrieveByIdIfValidationErrorOccursAndLogIt()
        {
            //given
            int someMenuId = GetRandomNumber();
            var argumentNullException = new ArgumentNullException();

            var nullArgumentMenuException =
                new NullArgumentMenuException(argumentNullException);

            var expectedMenuDependencyValidationException =
                new MenuDepecdencyValidationException(
                    nullArgumentMenuException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectMenuById(It.IsAny<int>()))
                    .Throws(argumentNullException);

            //when
            Action retrieveMenuByIdAction = () =>
                this.menuService.RetrieveMenuById(someMenuId);

            //then
            Assert.Throws<MenuDepecdencyValidationException>(retrieveMenuByIdAction);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectMenuById(It.IsAny<int>()),
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
