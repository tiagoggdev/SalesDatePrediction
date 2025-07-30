CREATE OR ALTER VIEW [Sales].[SalesPrediction]
AS
SELECT
    c.custid,
    c.companyname AS CustomerName,
    MAX(o.orderdate) AS LastOrderDate,
    DATEADD(DAY, AVG(DATEDIFF(DAY, prev.orderdate, o.orderdate)), MAX(o.orderdate)) AS NextPredictedOrder
FROM Sales.Customers c
JOIN Sales.Orders o ON o.custid = c.custid
JOIN Sales.Orders prev ON prev.custid = o.custid AND prev.orderdate < o.orderdate
GROUP BY c.companyname, c.custid;
GO
