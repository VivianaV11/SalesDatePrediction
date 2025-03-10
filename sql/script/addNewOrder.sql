
-- Add New Order
BEGIN TRANSACTION;

DECLARE @OrderIDTable TABLE (OrderID INT);

INSERT INTO [Sales].[Orders] (Custid, Empid, Shipperid, Shipname, Shipaddress, Shipcity, Orderdate, Requireddate, Shippeddate, Freight, Shipcountry)
OUTPUT INSERTED.Orderid INTO @OrderIDTable
VALUES (65, 3, 3, 'DanteStore', 'Calle 50 #12-34','Bogotá', GETDATE(), DATEADD(DAY, 10, GETDATE()), NULL, 75.50, 'CO');

DECLARE @OrderID INT = (SELECT OrderID FROM @OrderIDTable);

INSERT INTO [Sales].[OrderDetails] (Orderid, Productid, Unitprice, Qty, Discount)
VALUES (@OrderID, 5, 35, 3, 0.2);

COMMIT TRANSACTION;
