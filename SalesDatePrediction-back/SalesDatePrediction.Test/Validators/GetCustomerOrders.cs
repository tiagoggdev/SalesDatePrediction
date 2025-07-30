using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation.TestHelper;
using SalesDatePrediction.Application.UseCases.Commands.CreateOrder;
using SalesDatePrediction.Application.UseCases.Queries.GetCustomerOrders;

namespace SalesDatePrediction.Test.Validators
{
    public class GetCustomerOrders
    {
        private readonly GetCustomerOrdersValidator _validator = new();

        [Fact]
        public void Should_Have_Error_When_CustomerId_Is_Zero()
        {
            var query = new GetCustomerOrdersQuery
            {
                CustomerId = 0,
                PageNumber = 1,
                PageSize = 10
            };

            var result = _validator.TestValidate(query);

            result.ShouldHaveValidationErrorFor(q => q.CustomerId);
        }

        [Fact]
        public void Should_Have_Error_When_PageNumber_Is_Less_Than_1()
        {
            var query = new GetCustomerOrdersQuery
            {
                CustomerId = 1,
                PageNumber = 0,
                PageSize = 10
            };

            var result = _validator.TestValidate(query);

            result.ShouldHaveValidationErrorFor(q => q.PageNumber);
        }

        [Fact]
        public void Should_Have_Error_When_PageSize_Is_Less_Than_1()
        {
            var query = new GetCustomerOrdersQuery
            {
                CustomerId = 1,
                PageNumber = 1,
                PageSize = -1
            };

            var result = _validator.TestValidate(query);

            result.ShouldHaveValidationErrorFor(q => q.PageSize);
        }

        [Fact]
        public void Should_Not_Have_Errors_When_Valid()
        {
            var query = new GetCustomerOrdersQuery
            {
                CustomerId = 1,
                PageNumber = 1,
                PageSize = 20
            };

            var result = _validator.TestValidate(query);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}