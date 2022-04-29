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
        private delegate List<Menu> ReturningMenusFunction();

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
            catch (InvalidMenuException invalidMenuException)
            {
                throw CreateAndLogValidationException(invalidMenuException);
            }
            catch (Exception exception)
            {
                var failedMenuServiceException =
                    new FailedMenuServiceException(exception);

                throw CreateAndLogServiceException(failedMenuServiceException);
            }
        }

        private List<Menu> TryCatch(ReturningMenusFunction returningMenusFunction)
        {
            try
            {
                return returningMenusFunction();
            }
            catch (Exception exception)
            {
                var failedMenuServiceException =
                    new FailedMenuServiceException(exception);

                throw CreateAndLogServiceException(
                    failedMenuServiceException);
            }
        }

        private MenuValidationException CreateAndLogValidationException(Xeption exception)
        {
            var menuValidationException = new MenuValidationException(exception);
            this.loggingBroker.LogError(menuValidationException);

            return menuValidationException;
        }

        private MenuServiceException CreateAndLogServiceException(Xeption exception)
        {
            var menuServiceException = new MenuServiceException(exception);
            this.loggingBroker.LogError(menuServiceException);

            return menuServiceException;
        }
    }
}
