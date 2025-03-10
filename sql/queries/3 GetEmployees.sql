-- 3. Get employees
USE [StoreSample]
GO

SELECT 
    empid AS Empid,
    CONCAT(firstname, ' ',lastname) AS FullName
FROM 
    [HR].[Employees];

GO