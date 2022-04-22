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
        public void ShouldAddMenu()
        {
            //given
            Menu randomMenu = CreateRandomMenu();
            Menu inputMenu = randomMenu;
            Menu persistedMenu = inputMenu;
            Menu expectedMenu = persistedMenu.DeepClone();

            this.storageBrokerMock.Setup(brokers =>
                brokers.InsertMenu(inputMenu))
                    .Returns(expectedMenu);

            //when
            Menu actualMenu = this.menuService.AddMenu(inputMenu);

            //then
            actualMenu.Should().BeEquivalentTo(expectedMenu);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertMenu(inputMenu),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
