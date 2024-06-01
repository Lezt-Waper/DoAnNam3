CREATE PROCEDURE [dbo].[spOrderDetail_Insert]
	@OrderId int,
	@GoodId NVARCHAR(20),
	@Quantity int
AS
begin
	INSERT INTO [dbo].[OrderDetail] (OrderId, GoodId, Quantity)
	VALUES (@OrderId, @GoodId, @Quantity)
end
