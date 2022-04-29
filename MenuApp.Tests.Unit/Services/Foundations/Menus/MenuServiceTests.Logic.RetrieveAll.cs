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
        public void ShouldRetrieveAllMenus()
        {
            //given
            List<Menu> randomMenus = CreateRandomMenus();
            List<Menu> persistedMenus = randomMenus;
            List<Menu> expectedMenus = persistedMenus.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllMenus())
                    .Returns(expectedMenus);

            //when
            List<Menu> actualMenus =
                this.menuService.RetrieveAllMenus();

            //then
            actualMenus.Should().BeEquivalentTo(expectedMenus);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllMenus(),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
