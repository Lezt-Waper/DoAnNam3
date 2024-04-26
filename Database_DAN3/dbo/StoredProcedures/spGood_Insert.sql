CREATE PROCEDURE [dbo].[spGood_Insert]
	@CategoryId int,
	@Name NVARCHAR(20),
	@Quantity int
AS
begin
	INSERT INTO [dbo].[Good] (CategoryId, Name, Quantity)
	VALUES (@CategoryId, @Name, @Quantity)
end
