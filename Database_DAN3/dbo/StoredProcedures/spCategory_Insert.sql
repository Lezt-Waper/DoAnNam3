CREATE PROCEDURE [dbo].[spCategory_Insert]
	@CategoryName NVARCHAR(20)
AS
begin
	INSERT INTO [dbo].[Category] (CategoryName)
	VALUES (@CategoryName)
end
