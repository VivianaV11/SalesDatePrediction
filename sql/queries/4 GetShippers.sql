--4. Get Shippers
USE [StoreSample]
GO
SELECT DISTINCT shipperid, companyname FROM [Sales].[Shippers];
GO