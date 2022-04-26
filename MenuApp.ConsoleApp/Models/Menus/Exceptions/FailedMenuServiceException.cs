// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace MenuApp.ConsoleApp.Models.Menus.Exceptions
{
    public class FailedMenuServiceException : Xeption
    {
        public FailedMenuServiceException(Exception innerException)
            : base(message: "Failed menu service error occurred, please contact support.",
                  innerException)
        { }
    }
}
