// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace MenuApp.ConsoleApp.Models.Menus.Exceptions
{
    public class MenuServiceException : Xeption
    {
        public MenuServiceException(Xeption innerException)
            : base(message: "Menu serivce error occurred, contact support.",
                  innerException)
        { }
    }
}