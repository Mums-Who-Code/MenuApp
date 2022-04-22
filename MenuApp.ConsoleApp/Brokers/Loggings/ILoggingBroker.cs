// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

namespace MenuApp.ConsoleApp.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        void LogError(Exception exception);
    }
}
