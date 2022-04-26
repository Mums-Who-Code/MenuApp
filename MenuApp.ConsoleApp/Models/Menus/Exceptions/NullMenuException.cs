// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace MenuApp.ConsoleApp.Models.Menus.Exceptions
{
    public class NullMenuException : Xeption
    {
        public NullMenuException()
            : base(message: "Menu is null.")
        { }
    }
}
