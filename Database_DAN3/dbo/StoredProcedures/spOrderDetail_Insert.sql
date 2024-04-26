CREATE PROCEDURE [dbo].[spOrderDetail_Insert]
	@OrderId int,
	@GoodId int,
	@Quantity int
AS
begin
	INSERT INTO [dbo].[OrderDetail] (OrderId, GoodId, Quantity)
	VALUES (@OrderId, @GoodId, @Quantity)
end
