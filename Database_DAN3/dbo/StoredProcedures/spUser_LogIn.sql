CREATE PROCEDURE [dbo].[spUser_LogIn]
	@UserName NVARCHAR(20),
	@Password NVARCHAR(20)
AS
begin
	SELECT Id
	FROM [dbo].[User]
	WHERE UserName = @UserName AND Password = @Password
end
