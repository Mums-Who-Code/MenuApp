// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using MenuApp.ConsoleApp.Models.Menus;
using MenuApp.ConsoleApp.Models.Menus.Exceptions;

namespace MenuApp.ConsoleApp.Services.Foundations.Menus
{
    public partial class MenuService
    {
        private static void ValidateMenu(Menu menu)
        {
            if (menu == null)
            {
                throw new NullMenuException();
            }
        }
    }
}
