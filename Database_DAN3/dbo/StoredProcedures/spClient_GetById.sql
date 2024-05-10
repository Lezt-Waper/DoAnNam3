CREATE PROCEDURE [dbo].[spClient_GetById]
	@Id int
AS
begin
	SELECT Id AS ClientId, Name, PhoneNumber, Credit, Address
	FROM [dbo].[Client]
	WHERE Id = @Id
end