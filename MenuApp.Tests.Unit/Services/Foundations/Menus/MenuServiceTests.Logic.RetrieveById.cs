// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using FluentAssertions;
using Force.DeepCloner;
using MenuApp.ConsoleApp.Models.Menus;
using Moq;
using Xunit;

namespace MenuApp.Tests.Unit.Services.Foundations.Menus
{
    public partial class MenuServiceTests
    {
        [Fact]
        public void ShouldRetrieveMenuById()
        {
            //given
            Menu randomMenu = CreateRandomMenu();
            Menu inputMenu = randomMenu;
            Menu storageMenu = inputMenu;
            Menu expectedMenu = storageMenu.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectMenuById(inputMenu.Id))
                    .Returns(storageMenu);

            //when
            Menu actualMenu =
                this.menuService.RetrieveMenuById(inputMenu.Id);

            //then
            actualMenu.Should().BeEquivalentTo(expectedMenu);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectMenuById(inputMenu.Id),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
