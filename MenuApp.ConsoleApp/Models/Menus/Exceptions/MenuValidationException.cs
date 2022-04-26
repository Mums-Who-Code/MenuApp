// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace MenuApp.ConsoleApp.Models.Menus.Exceptions
{
    public class MenuValidationException : Xeption
    {
        public MenuValidationException(Xeption innerException)
            : base(message: "Menu validation error occurred, " +
                  "please fix the error and try again.",
                  innerException)
        { }
    }
}
