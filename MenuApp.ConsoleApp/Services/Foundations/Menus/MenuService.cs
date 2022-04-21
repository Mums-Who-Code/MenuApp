// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using MenuApp.ConsoleApp.Brokers.Storages;
using MenuApp.ConsoleApp.Models.Menus;

namespace MenuApp.ConsoleApp.Services.Foundations.Menus
{
    public class MenuService : IMenuService
    {
        private readonly IStorageBroker storageBroker;

        public MenuService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public Menu AddMenu(Menu menu)
        {
            throw new NotImplementedException();
        }
    }
}
