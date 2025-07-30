using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.UseCases.Commands.CreateOrder;
using SalesDatePrediction.Domain.Entities;
using SalesDatePrediction.Infrastructure.Data;
using SalesDatePrediction.Test.Utils;

namespace SalesDatePrediction.Test.Handlers
{
    public class CreateOrderTests
    {
        [Fact]
        public async Task Should_Fail_When_CustomerDoesNotExist()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var context = new AppDbContext(options);
            TestSeedData.SeedRequiredData(context);

            var handler = new CreateOrderHandler(context);

            var command = new CreateOrderCommand
            {
                CustId = 99999,
                Empid = 1,
                Shipperid = 1,
                Productid = 1,
                Shipname = "Test",
                Shipaddress = "Test",
                Shipcity = "Test",
                Orderdate = DateTime.UtcNow,
                Requireddate = DateTime.UtcNow.AddDays(5),
                Shippeddate = DateTime.UtcNow.AddDays(1),
                Freight = 10,
                Shipcountry = "Test",
                Unitprice = 5,
                Qty = 2,
                Discount = 0
            };

            var result = await handler.Handle(command, CancellationToken.None);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("El cliente no existe.");
        }

        [Fact]
        public async Task Should_Fail_When_EmployeeDoesNotExist()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var context = new AppDbContext(options);
            TestSeedData.SeedRequiredData(context);

            var handler = new CreateOrderHandler(context);

            var command = new CreateOrderCommand
            {
                CustId = 1,
                Empid = 99999,
                Shipperid = 1,
                Productid = 1,
                Shipname = "Test",
                Shipaddress = "Test",
                Shipcity = "Test",
                Orderdate = DateTime.UtcNow,
                Requireddate = DateTime.UtcNow.AddDays(5),
                Shippeddate = DateTime.UtcNow.AddDays(1),
                Freight = 10,
                Shipcountry = "Test",
                Unitprice = 5,
                Qty = 2,
                Discount = 0
            };

            var result = await handler.Handle(command, CancellationToken.None);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("El empleado no existe.");
        }

        [Fact]
        public async Task Should_Fail_When_ShipperDoesNotExist()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var context = new AppDbContext(options);
            TestSeedData.SeedRequiredData(context);

            var handler = new CreateOrderHandler(context);

            var command = new CreateOrderCommand
            {
                CustId = 1,
                Empid = 1,
                Shipperid = 9999,
                Productid = 1,
                Shipname = "Test",
                Shipaddress = "Test",
                Shipcity = "Test",
                Orderdate = DateTime.UtcNow,
                Requireddate = DateTime.UtcNow.AddDays(5),
                Shippeddate = DateTime.UtcNow.AddDays(1),
                Freight = 10,
                Shipcountry = "Test",
                Unitprice = 5,
                Qty = 2,
                Discount = 0
            };

            var result = await handler.Handle(command, CancellationToken.None);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("El transportista no existe.");
        }

        [Fact]
        public async Task Should_Fail_When_ProductDoesNotExist()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var context = new AppDbContext(options);
            TestSeedData.SeedRequiredData(context);

            var handler = new CreateOrderHandler(context);

            var command = new CreateOrderCommand
            {
                CustId = 1,
                Empid = 1,
                Shipperid = 1,
                Productid = 9999,
                Shipname = "Test",
                Shipaddress = "Test",
                Shipcity = "Test",
                Orderdate = DateTime.UtcNow,
                Requireddate = DateTime.UtcNow.AddDays(5),
                Shippeddate = DateTime.UtcNow.AddDays(1),
                Freight = 10,
                Shipcountry = "Test",
                Unitprice = 5,
                Qty = 2,
                Discount = 0
            };

            var result = await handler.Handle(command, CancellationToken.None);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("El producto no existe.");
        }

    }
}
