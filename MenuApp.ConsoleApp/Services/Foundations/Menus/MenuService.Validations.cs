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
            ValidateMenuIsNotNull(menu);

            Validate(
                (Rule: IsInvalid(menu.Id), Parameter: nameof(Menu.Id)),
                (Rule: IsInvalid(menu.ItemName), Parameter: nameof(Menu.ItemName)),
                (Rule: IsInvalid(menu.Price), Parameter: nameof(Menu.Price)));
        }

        private static void ValidateInputId(int id) =>
            Validate((Rule: IsInvalid(id), Parameter: nameof(Menu.Id)));

        private static dynamic IsInvalid(int id) => new
        {
            Condition = id == default,
            Message = "Id is required."
        };

        private static dynamic IsInvalid(string itemName) => new
        {
            Condition = string.IsNullOrWhiteSpace(itemName),
            Message = "ItemName is required."
        };

        private static dynamic IsInvalid(double price) => new
        {
            Condition = price == default,
            Message = "Price is required."
        };

        private static void ValidateMenuIsNotNull(Menu menu)
        {
            if (menu == null)
            {
                throw new NullMenuException();
            }
        }

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidMenuException = new InvalidMenuException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidMenuException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidMenuException.ThrowIfContainsErrors();
        }
    }
}
