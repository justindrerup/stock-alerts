﻿using System.Collections.Generic;
using System.Linq;

namespace StockAlerts.Domain.Specifications
{
    public class OrSpecification<TCandidate> : CompositeSpecification<TCandidate>
    {
        public override bool IsSatisfiedBy(TCandidate candidate)
        {
            if (!_childSpecifications.Any()) return false;

            foreach (var s in _childSpecifications)
            {
                if (s.IsSatisfiedBy(candidate)) return true;
            }

            return false;
        }
    }
}