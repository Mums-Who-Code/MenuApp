// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using MenuApp.ConsoleApp.Models.Menus;

namespace MenuApp.ConsoleApp.Brokers.Storages
{
    internal partial class StorageBroker : IStorageBroker
    {
        List<Menu> Menus = new List<Menu>();

        public Menu InsertMenu(Menu menu)
        {
            Menus.Add(menu);

            return menu;
        }
    }
}
