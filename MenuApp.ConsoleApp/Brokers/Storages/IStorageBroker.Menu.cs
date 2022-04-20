// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using MenuApp.ConsoleApp.Models.Menus;

namespace MenuApp.ConsoleApp.Brokers.Storages
{
    internal partial interface IStorageBroker
    {
        Menu InsertMenu(Menu menu);
    }
}
