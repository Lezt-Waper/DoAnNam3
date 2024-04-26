CREATE PROCEDURE [dbo].[spClient_GetById]
	@Id int
AS
begin
	SELECT	Name, PhoneNumber, Credit, Address
	FROM [dbo].[Client]
	WHERE Id = @Id
end