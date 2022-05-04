// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using MenuApp.ConsoleApp.Models.Menus;

namespace MenuApp.ConsoleApp.Services.Foundations.Menus
{
    public interface IMenuService
    {
        Menu AddMenu(Menu menu);
        List<Menu> RetrieveAllMenus();
        Menu RetrieveMenuById(int id);
    }
}
