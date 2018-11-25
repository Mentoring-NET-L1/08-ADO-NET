﻿SELECT [OrderID]
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
  WHERE [OrderID] = @id;

SELECT [Details].[UnitPrice]
      ,[Details].[Quantity]
      ,[Details].[Discount]
	  ,[Products].[ProductID]
      ,[Products].[ProductName]
      ,[Products].[QuantityPerUnit]
      ,[Products].[UnitPrice]
      ,[Products].[UnitsInStock]
      ,[Products].[UnitsOnOrder]
      ,[Products].[ReorderLevel]
      ,[Products].[Discontinued]
  FROM [dbo].[Order Details] AS [Details]
  JOIN [dbo].[Products] AS [Products]
    ON [Details].[ProductID] = [Products].[ProductID]
  WHERE [OrderID] = @Id;
