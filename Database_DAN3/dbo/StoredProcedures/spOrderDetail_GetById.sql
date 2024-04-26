CREATE PROCEDURE [dbo].[spOrderDetail_GetById]
	@Id int
AS
begin
	SELECT OD.Id, OD.Quantity, OD.IsDelivery, G.Id AS GoodId, G.Name, G.Quantity
	FROM [dbo].[OrderDetail] OD
	INNER JOIN [dbo].[Good] G
		ON OD.GoodId = G.Id
	WHERE OD.Id = @Id
end
