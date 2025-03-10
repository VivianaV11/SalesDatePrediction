WITH OrderIntervals AS (
    SELECT 
        o.custid,
        o.orderdate,
        LAG(o.orderdate) OVER (PARTITION BY o.custid ORDER BY o.orderdate) AS prev_order_date
    FROM Sales.Orders o
),
CustomerOrderStats AS (
    SELECT 
        o.custid,
        MAX(o.orderdate) AS LastOrderDate,
        ROUND(SUM(DATEDIFF(DAY, oi.prev_order_date, oi.orderdate)) / COUNT(o.orderdate), 0) AS AvgDaysBetweenOrders
    FROM Sales.Orders o
    LEFT JOIN OrderIntervals oi ON o.custid = oi.custid AND o.orderdate = oi.orderdate
    GROUP BY o.custid
)
SELECT 
    c.companyname AS CustomerName,
    cos.LastOrderDate,
    DATEADD(DAY, cos.AvgDaysBetweenOrders, cos.LastOrderDate) AS NextPredictedOrder
FROM CustomerOrderStats cos
JOIN Sales.Customers c ON cos.custid = c.custid
ORDER BY c.companyname;
