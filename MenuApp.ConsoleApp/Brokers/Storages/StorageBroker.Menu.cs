// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using MenuApp.ConsoleApp.Models.Menus;

namespace MenuApp.ConsoleApp.Brokers.Storages
{
    public partial class StorageBroker : IStorageBroker
    {
        List<Menu> Menus = new List<Menu>();

        public Menu InsertMenu(Menu menu)
        {
            Menus.Add(menu);

            return menu;
        }

        public List<Menu> SelectAllMenus() => Menus;

        public Menu SelectMenuById(int id) =>
            Menus.Find(menu => menu.Id == id);

        public Menu UpdateMenu(Menu inputMenu)
        {
            Menus.RemoveAll(menu => menu.Id == inputMenu.Id);
            Menus.Add(inputMenu);

            return inputMenu;
        }

        public Menu DeleteMenu(Menu inputMenu)
        {
            Menus.Remove(inputMenu);

            return inputMenu;
        }
    }
}
