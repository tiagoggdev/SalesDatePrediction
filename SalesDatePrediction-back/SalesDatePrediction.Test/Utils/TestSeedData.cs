using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesDatePrediction.Domain.Entities;
using SalesDatePrediction.Infrastructure.Data;

namespace SalesDatePrediction.Test.Utils
{
    public static class TestSeedData
    {
        public static void SeedRequiredData(AppDbContext context)
        {
            if (!context.Employees.Any())
            {
                context.Employees.AddRange(new Employee
                {
                    Empid = 1,
                    Firstname = "Juan",
                    Lastname = "Pérez",
                    Title = "Developer",
                    Titleofcourtesy = "Mr.",
                    Birthdate = new DateTime(1990, 1, 1),
                    Hiredate = DateTime.UtcNow.AddYears(-5),
                    Address = "123 Calle",
                    City = "Bogotá",
                    Country = "Colombia",
                    Phone = "1234567890"
                },
                new Employee
                {
                    Empid = 2,
                    Firstname = "Ana",
                    Lastname = "Gómez",
                    Title = "QA",
                    Titleofcourtesy = "Ms",
                    Birthdate = DateTime.UtcNow.AddYears(-28),
                    Hiredate = DateTime.UtcNow.AddYears(-4),
                    Address = "Av Siempre Viva",
                    City = "Medellín",
                    Country = "Colombia",
                    Phone = "789456"
                }
                );
            }

            if (!context.Customers.Any())
            {
                context.Customers.Add(new Customer
                {
                    Custid = 1,
                    Companyname = "Empresa S.A.",
                    Contactname = "Ana Torres",
                    Contacttitle = "CEO",
                    Address = "Cra 123",
                    City = "Medellín",
                    Country = "Colombia",
                    Phone = "0987654321"
                });
            }

            if (!context.Shippers.Any())
            {
                context.Shippers.Add(new Shipper
                {
                    Shipperid = 1,
                    Companyname = "FastShip",
                    Phone = "111222333"
                });
            }

            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category
                {
                    Categoryid = 1,
                    Categoryname = "Tecnología",
                    Description = "Dispositivos electrónicos"
                });
            }

            if (!context.Suppliers.Any())
            {
                context.Suppliers.Add(new Supplier
                {
                    Supplierid = 1,
                    Companyname = "GlobalTech",
                    Contactname = "Carlos Ramírez",
                    Contacttitle = "Sales Manager",
                    Address = "Av. Central 45",
                    City = "Cali",
                    Country = "Colombia",
                    Phone = "3001112233"
                });
            }

            if (!context.Products.Any())
            {
                context.Products.Add(new Product
                {
                    Productid = 1,
                    Productname = "Laptop Lenovo",
                    Categoryid = 1,
                    Supplierid = 1,
                    Unitprice = 2500,
                    Discontinued = false
                });
            }

            context.SaveChanges();
        }
    }

}