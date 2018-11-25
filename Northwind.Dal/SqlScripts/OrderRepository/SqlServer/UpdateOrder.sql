UPDATE [dbo].[Orders] 
SET [RequiredDate] = @RequiredDate, 
    [ShipName] = @ShipName,
    [ShipAddress] = @ShipAddress,
    [ShipCity] = @ShipCity,
    [ShipRegion] = @ShipRegion,
    [ShipPostalCode] = @ShipPostalCode,
    [ShipCountry] = @ShipCountry
WHERE
    [OrderID] = @Id;

SELECT [OrderID]
      ,[OrderDate]
      ,[RequiredDate]
      ,[ShippedDate]
      ,[ShipName]
      ,[ShipAddress]
      ,[ShipCity]
      ,[ShipRegion]
      ,[ShipPostalCode]
      ,[ShipCountry]
  FROM [dbo].[Orders]
  WHERE [OrderID] = @Id;
