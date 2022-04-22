// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace MenuApp.ConsoleApp.Models.Menus.Exceptions
{
    public class InvalidMenuException : Xeption
    {
        public InvalidMenuException()
            : base(message: "Menu is invalid, please fix the error and try again")
        { }
    }
}
