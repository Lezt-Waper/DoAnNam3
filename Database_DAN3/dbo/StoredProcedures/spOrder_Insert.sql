CREATE PROCEDURE [dbo].[spOrder_Insert]
	@ClientId int,
	@Total int
AS
begin
	INSERT INTO [dbo].[Order] (ClientId, ToTal)
	VALUES (@ClientId, @Total)
end
