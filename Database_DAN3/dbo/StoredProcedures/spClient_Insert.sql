CREATE PROCEDURE [dbo].[spClient_Insert]
	@Name NVARCHAR(50),
	@PhoneNumber NVARCHAR(15),
	@Credit NVARCHAR(19), 
	@Address NVARCHAR(50)
AS	
begin
	INSERT INTO [dbo].[Client] (Name, PhoneNumber, Credit, Address)
	VALUES (@Name, @PhoneNumber, @Credit, @Address)

	SELECT SCOPE_IDENTITY()
end
