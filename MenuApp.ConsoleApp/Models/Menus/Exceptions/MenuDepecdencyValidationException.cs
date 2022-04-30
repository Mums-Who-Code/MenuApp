// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace MenuApp.ConsoleApp.Models.Menus.Exceptions
{
    public class MenuDepecdencyValidationException : Xeption
    {
        public MenuDepecdencyValidationException(Xeption innerException)
            : base(message: "Menu dependency validation error occurred, please fix the errors and try again.",
                  innerException)
        { }
    }
}
