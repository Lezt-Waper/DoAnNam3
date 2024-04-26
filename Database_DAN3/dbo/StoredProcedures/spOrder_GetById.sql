CREATE PROCEDURE [dbo].[spOrder_GetById]
	@Id int
AS
begin
	SELECT O.Id, O.ToTal, 
		C.Id AS ClientId, C.Name, C.PhoneNumber, C.Credit, C.Address,
		OD.Id AS OrderDetailId, OD.Quantity, OD.IsDelivery,
		G.Id AS GoodId, G.Name, G.Quantity
	FROM [dbo].[Order] O
	INNER JOIN [dbo].[Client] C
		ON O.ClientId = C.Id
	INNER JOIN [dbo].[OrderDetail] OD
		ON O.Id = OD.OrderId
	INNER JOIN [dbo].[Good] G
		ON OD.GoodId = G.Id
	WHERE O.Id = @Id
end
