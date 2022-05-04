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
            catch (ArgumentNullException argumentNullException)
            {
                var nullArgumentMenuException =
                    new NullArgumentMenuException(argumentNullException);

                throw CreateAndLogDependencyValidationException(
                    nullArgumentMenuException);
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

        private MenuDepecdencyValidationException CreateAndLogDependencyValidationException(Xeption exception)
        {
            var menuDepecdencyValidationException = new MenuDepecdencyValidationException(exception);
            this.loggingBroker.LogError(menuDepecdencyValidationException);

            return menuDepecdencyValidationException;
        }

        private MenuServiceException CreateAndLogServiceException(Xeption exception)
        {
            var menuServiceException = new MenuServiceException(exception);
            this.loggingBroker.LogError(menuServiceException);

            return menuServiceException;
        }
    }
}
