UPDATE [dbo].[Orders] 
SET [OrderDate] = @OrderDate
WHERE [OrderID] = @Id;
