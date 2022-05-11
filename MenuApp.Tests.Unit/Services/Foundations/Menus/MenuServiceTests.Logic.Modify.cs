// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using FluentAssertions;
using MenuApp.ConsoleApp.Models.Menus;
using Moq;
using Xunit;

namespace MenuApp.Tests.Unit.Services.Foundations.Menus
{
    public partial class MenuServiceTests
    {
        [Fact]
        public void ShouldModifyMenu()
        {
            //given
            Menu randomMenu = CreateRandomMenu();
            Menu inputMenu = randomMenu;
            Menu modifiedMenu = inputMenu;
            Menu epectedMenu = modifiedMenu;

            this.storageBrokerMock.Setup(broker =>
                broker.UpdateMenu(inputMenu))
                    .Returns(modifiedMenu);

            //when
            Menu actualMenu = this.menuService.ModifyMenu(inputMenu);

            //then
            actualMenu.Should().BeEquivalentTo(epectedMenu);

            this.storageBrokerMock.Verify(broker =>
                broker.UpdateMenu(inputMenu),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
