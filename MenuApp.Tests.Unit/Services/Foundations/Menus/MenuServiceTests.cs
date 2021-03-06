// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System.Linq.Expressions;
using MenuApp.ConsoleApp.Brokers.Loggings;
using MenuApp.ConsoleApp.Brokers.Storages;
using MenuApp.ConsoleApp.Models.Menus;
using MenuApp.ConsoleApp.Services.Foundations.Menus;
using Moq;
using Tynamix.ObjectFiller;
using Xeptions;

namespace MenuApp.Tests.Unit.Services.Foundations.Menus
{
    public partial class MenuServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IMenuService menuService;

        public MenuServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.menuService = new MenuService(
                storageBroker: this.storageBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private static Expression<Func<Xeption, bool>> SameExceptionAs(Exception expectedException)
        {
            return actualException =>
                actualException.Message == expectedException.Message
                && actualException.InnerException.Message == expectedException.InnerException.Message
                && (actualException.InnerException as Xeption).DataEquals(expectedException.InnerException.Data);
        }

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static List<Menu> CreateRandomMenus() =>
            CreateMenuFiller().Create(count: GetRandomNumber()).ToList();

        private static Menu CreateRandomMenu() =>
            CreateMenuFiller().Create();

        private static Filler<Menu> CreateMenuFiller() =>
            new Filler<Menu>();
    }
}