﻿using System;

namespace StockAlerts.Domain.Model
{
    public class Stock
    {
        public Guid StockId { get; set; }

        public string Symbol { get; set; }

        public decimal LastPrice { get; set; }
    }
}
