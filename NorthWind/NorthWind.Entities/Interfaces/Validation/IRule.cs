﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Interfaces.Validation
{
    public interface IRule<T>
    {
        IRule<T> AddRequirement(
            Expression<Func<T, bool>> requirement, string errorMessage);
        IRule<T> AddCollectionItemsValidators(
            Expression<Func<T, IEnumerable<IFailure>>> itemsValidator);
    }
}
