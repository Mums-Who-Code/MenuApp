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
            List<Menu> storedSamples = menuService.RetrieveAllMenus();
        }
    }
}