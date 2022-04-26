// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using MenuApp.ConsoleApp.Brokers.Loggings;
using MenuApp.ConsoleApp.Brokers.Storages;
using MenuApp.ConsoleApp.Models.Menus;

namespace MenuApp.ConsoleApp.Services.Foundations.Menus
{
    public partial class MenuService : IMenuService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public MenuService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public Menu AddMenu(Menu menu) =>
        TryCatch(() =>
        {
            ValidateMenu(menu);

            return this.storageBroker.InsertMenu(menu);
        });
    }
}
