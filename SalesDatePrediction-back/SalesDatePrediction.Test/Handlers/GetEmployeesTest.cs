using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.UseCases.Queries.GetEmployees;
using SalesDatePrediction.Infrastructure.Data;
using SalesDatePrediction.Test.Utils;

namespace SalesDatePrediction.Test.Handlers
{
    public class GetEmployeesTest
    {
        //[Fact]
        //public async Task Should_Return_Paginated_Employees()
        //{
        //    var options = new DbContextOptionsBuilder<AppDbContext>()
        //        .UseInMemoryDatabase(Guid.NewGuid().ToString())
        //        .Options;

        //    using var context = new AppDbContext(options);
        //    TestSeedData.SeedRequiredData(context);

        //    var handler = new GetEmployeesHandler(context);

        //    var query = new GetEmployeesQuery
        //    {
        //        PageNumber = 1,
        //        PageSize = 2
        //    };

        //    var result = await handler.Handle(query, CancellationToken.None);

        //    result.IsSuccess.Should().BeTrue();
        //    result.Value!.Items.Should().HaveCount(2);
        //    result.Value.TotalItems.Should().BeGreaterThanOrEqualTo(2);
        //    result.Value.PageNumber.Should().Be(1);
        //    result.Value.PageSize.Should().Be(2);
        //}

        //[Fact]
        //public async Task Should_Return_Empty_When_No_Employees()
        //{
        //    var options = new DbContextOptionsBuilder<AppDbContext>()
        //        .UseInMemoryDatabase(Guid.NewGuid().ToString())
        //        .Options;

        //    using var context = new AppDbContext(options);

        //    var handler = new GetEmployeesHandler(context);

        //    var query = new GetEmployeesQuery
        //    {
        //        PageNumber = 1,
        //        PageSize = 10
        //    };

        //    var result = await handler.Handle(query, CancellationToken.None);

        //    result.IsSuccess.Should().BeTrue();
        //    result.Value!.Items.Should().BeEmpty();
        //    result.Value.TotalItems.Should().Be(0);
        //}
    }
}
