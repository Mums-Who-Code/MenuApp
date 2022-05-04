// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace MenuApp.ConsoleApp.Models.Menus.Exceptions
{
    public class NullArgumentMenuException : Xeption
    {
        public NullArgumentMenuException(Exception innerException)
            : base(message: "Null argument menu error occurred, please fix the errors and try again.",
                  innerException)
        { }
    }
}
