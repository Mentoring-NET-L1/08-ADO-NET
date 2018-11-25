UPDATE [dbo].[Orders] 
SET [ShippedDate] = @ShippedDate
WHERE [OrderID] = @Id;
