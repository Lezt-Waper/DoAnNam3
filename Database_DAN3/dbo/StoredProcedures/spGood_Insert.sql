CREATE PROCEDURE [dbo].[spGood_Insert]
	@CategoryId int,
	@Name NVARCHAR(20),
	@Price INT,
	@Quantity int
AS
begin
	INSERT INTO [dbo].[Good] (CategoryId, Name, Price, Quantity)
	VALUES (@CategoryId, @Name, @Price, @Quantity)
end
