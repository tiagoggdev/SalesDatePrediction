USE StoreSample;
GO

DECLARE @CustomerId INT = 1;

SELECT 
    Orderid,
    Requireddate,
    Shippeddate,
    Shipname,
    Shipaddress,
    Shipcity
FROM Sales.Orders
WHERE Custid = @CustomerId
ORDER BY Orderdate DESC;