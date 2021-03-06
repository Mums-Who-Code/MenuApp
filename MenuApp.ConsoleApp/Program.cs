// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using MenuApp.ConsoleApp.Brokers.Loggings;
using MenuApp.ConsoleApp.Brokers.Storages;
using MenuApp.ConsoleApp.Models.Menus;
using MenuApp.ConsoleApp.Services.Foundations.Menus;
using Microsoft.Extensions.Logging;

namespace MenuApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var storageBroker = new StorageBroker();
            var loggerFactory = new LoggerFactory();
            var logger = new Logger<LoggingBroker>(loggerFactory);
            var loggingBroker = new LoggingBroker(logger);
            var menuService = new MenuService(storageBroker, loggingBroker);

            var inputMenu = new Menu()
            {
                Id = 10,
                ItemName = "Fried Rice",
                Price = 30.00
            };

            menuService.AddMenu(inputMenu);

            inputMenu = new Menu()
            {
                Id = 103456,
                ItemName = "Butter Chicken",
                Price = 50.00
            };

            menuService.AddMenu(inputMenu);
            List<Menu> storedMenus = menuService.RetrieveAllMenus();
            Menu returningMenu = menuService.RetrieveMenuById(10);

            inputMenu = new Menu()
            {
                Id = 10,
                ItemName = "Lemon Rice",
                Price = 22.00
            };

            Menu modifiedMenu = menuService.ModifyMenu(inputMenu);

            inputMenu = new Menu()
            {
                Id = 0,
                ItemName = "Record to be deleted",
                Price = 22.00
            };

            Menu deletedMenu = menuService.RemoveMenu(inputMenu);
        }
    }
}