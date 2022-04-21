using MenuApp.ConsoleApp.Brokers.Storages;
using MenuApp.ConsoleApp.Models.Menus;
using MenuApp.ConsoleApp.Services.Foundations.Menus;
using Moq;
using Tynamix.ObjectFiller;

namespace MenuApp.Tests.Unit.Services.Foundations.Menus
{
    public partial class MenuServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly IMenuService menuService;

        public MenuServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();

            this.menuService = new MenuService(
                storageBroker: this.storageBrokerMock.Object);
        }

        private static Menu CreateRandomMenu() =>
            CreateMenuFiller().Create();

        private static Filler<Menu> CreateMenuFiller() =>
            new Filler<Menu>();

    }
}