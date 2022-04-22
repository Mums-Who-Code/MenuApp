// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using MenuApp.ConsoleApp.Models.Menus;
using MenuApp.ConsoleApp.Models.Menus.Exceptions;
using Xeptions;

namespace MenuApp.ConsoleApp.Services.Foundations.Menus
{
    public partial class MenuService
    {
        private delegate Menu ReturningMenuFunction();

        private Menu TryCatch(ReturningMenuFunction returningMenuFunction)
        {
            try
            {
                return returningMenuFunction();
            }
            catch (NullMenuException nullMenuException)
            {
                throw CreateAndLogValidationException(nullMenuException);
            }
        }

        private MenuValidationException CreateAndLogValidationException(Xeption exception)
        {
            var menuValidationException = new MenuValidationException(exception);
            this.loggingBroker.LogError(menuValidationException);

            return menuValidationException;
        }
    }
}
