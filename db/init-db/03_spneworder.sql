-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
USE StoreSample;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Santiago Garcia>
-- Create date: <29/07/2025>
-- Description:	<SP to create an order and order detail>
-- =============================================
CREATE PROCEDURE Sales.AddOrderWithDetailsTest
	@Custid INT,
	@Empid INT,
    @Shipperid INT,
    @Shipname NVARCHAR(100),
    @Shipaddress NVARCHAR(100),
    @Shipcity NVARCHAR(50),
    @Orderdate DATETIME,
    @Requireddate DATETIME,
    @Shippeddate DATETIME,
    @Freight MONEY,
    @Shipcountry NVARCHAR(50),
    @Productid INT,
    @Unitprice MONEY,
    @Qty INT,
    @Discount FLOAT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @OrderId INT;

	INSERT INTO Sales.Orders (
        custid, empid, shipperid, shipname, shipaddress, shipcity,
        orderdate, requireddate, shippeddate, freight, shipcountry
    )
    VALUES (
        @Custid, @Empid, @Shipperid, @Shipname, @Shipaddress, @Shipcity,
        @Orderdate, @Requireddate, @Shippeddate, @Freight, @Shipcountry
    );

    SET @OrderId = SCOPE_IDENTITY();

    INSERT INTO Sales.OrderDetails (orderid, productid, unitprice, qty, discount)
    VALUES (@OrderId, @Productid, @Unitprice, @Qty, @Discount);

END
GO
