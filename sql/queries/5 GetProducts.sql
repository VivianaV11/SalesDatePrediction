-- 5. Get Products

USE [StoreSample]
GO

SELECT productid, productname
FROM [Production].[Products]
ORDER BY productid ASC;

GO