CREATE PROCEDURE [dbo].[spUser_SignUp]
	@UserName NVARCHAR(20),
	@Password NVARCHAR(20)
AS
begin
	INSERT INTO [dbo].[User] (UserName, Password)
	VALUES (@UserName, @Password)
end
