--Get Client Orders
USE [StoreSample]
GO

SELECT 
    orderid AS Orderid,
    requireddate AS Requireddate,
    shippeddate AS Shippeddate,
    shipname AS Shipname,
    shipaddress AS Shipaddress,
    shipcity AS Shipcity
FROM 
    [Sales].[Orders]
WHERE 
    custid = (SELECT custid FROM [Sales].[Customers] WHERE custid = 1);

GO
