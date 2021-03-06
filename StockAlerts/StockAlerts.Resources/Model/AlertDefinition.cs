﻿using System;
using StockAlerts.Core.Enums;

namespace StockAlerts.Resources.Model
{
    public class AlertDefinition
    {
        public Guid AlertDefinitionId { get; set; }

        public Guid AppUserId { get; set; }

        public Guid StockId { get; set; }

        public AlertDefinitionStatuses Status { get; set; }

        public DateTimeOffset? LastSent { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public AlertCriteria RootCriteria { get; set; }

        public Stock Stock { get; set; }
    }
}
