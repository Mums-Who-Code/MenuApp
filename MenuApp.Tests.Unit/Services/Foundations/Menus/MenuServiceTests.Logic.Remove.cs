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
        public void ShouldRemoveMenu()
        {
            // given
            Menu randomMenu = CreateRandomMenu();
            Menu inputMenu = randomMenu;
            Menu deletedMenu = inputMenu;
            Menu expectedMenu = deletedMenu.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.DeleteMenu(inputMenu))
                    .Returns(deletedMenu);

            // when
            Menu actualMenu = this.menuService.RemoveMenu(inputMenu);

            // then
            actualMenu.Should().BeEquivalentTo(expectedMenu);

            this.storageBrokerMock.Verify(broker =>
                broker.DeleteMenu(inputMenu),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
