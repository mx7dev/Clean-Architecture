using NorthWind.Entities.Interfaces.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Abstractions
{

    public abstract class ValidatorBase<T>
    {
        /*  CREAR LA ABSTRACCION BASE PARA LOS VALIDADORES */
        readonly IValidationService<T> Service;
        protected ValidatorBase(IValidationService<T> service)
        {
            this.Service = service;
        }
        public List<IFailure> Failures => Service.Failures;
        public IRule<T> AddRuleFor<TProperty>(Expression<Func<T, TProperty>> expression, bool StopOnFirstFailure) =>
            Service.AddRuleFor(expression, StopOnFirstFailure);

        public bool Validate(T instance) => Service.Validate(instance);

        public List<IFailure> SetValidatorFor<ItemsType>(IEnumerable<ItemsType> items, 
            IValidator<ItemsType> validator)=> Service.SetValidatorFor(items,validator);

        public IValidationService<T> ServiceValidator => Service;

    }
}
