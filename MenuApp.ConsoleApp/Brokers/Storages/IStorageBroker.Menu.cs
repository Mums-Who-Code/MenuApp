// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using MenuApp.ConsoleApp.Models.Menus;

namespace MenuApp.ConsoleApp.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        Menu InsertMenu(Menu menu);
    }
}
