CREATE PROCEDURE [dbo].[spOrder_GetAll]
AS
begin
	SELECT O.Id AS OrderId, O.ClientId, O.ToTal, 
		OD.Id AS OrderDetailId, OD.OrderId, OD.GoodId, G.Name AS GoodName, OD.Quantity, OD.IsDelivery
	FROM [dbo].[Order] O
	INNER JOIN [dbo].[OrderDetail] OD
		ON O.Id = OD.OrderId
	INNER JOIN [dbo].[Good] G
		ON OD.GoodId = G.Id
end
