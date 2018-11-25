INSERT INTO [dbo].[Orders] 
       ([OrderDate], [RequiredDate], [ShippedDate], [ShipName], [ShipAddress], [ShipCity], [ShipRegion], [ShipPostalCode], [ShipCountry])  
VALUES (@OrderDate, @RequiredDate, @ShippedDate, @ShipName, @ShipAddress, @ShipCity, @ShipRegion, @ShipPostalCode, @ShipCountry);

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
  WHERE [OrderID] IN (SELECT SCOPE_IDENTITY() AS [ScopeIdentity]);
