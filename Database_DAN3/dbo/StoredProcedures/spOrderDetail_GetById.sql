﻿CREATE PROCEDURE [dbo].[spOrderDetail_GetById]
	@Id int
AS
begin
	SELECT OD.Id AS OrderDetailId, OD.OrderId, G.Id AS GoodId, G.Name AS GoodName, OD.Quantity, OD.IsDelivery
	FROM [dbo].[OrderDetail] OD
	INNER JOIN [dbo].[Good] G
		ON OD.GoodId = G.Id
	WHERE OD.Id = @Id
end
