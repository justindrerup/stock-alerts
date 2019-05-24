﻿using System;

namespace StockAlerts.Domain.Settings
{
    public interface IAppSettings
    {
        string MarketOpenTime { get; }

        string MarketCloseTime { get; }

        DateTimeOffset MarketOpenUtc { get; }

        DateTimeOffset MarketCloseUtc { get; }
    }
}
