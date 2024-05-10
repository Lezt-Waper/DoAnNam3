CREATE PROCEDURE [dbo].[spClient_GetAll]
AS
begin
	SELECT Id AS ClientId, Name, PhoneNumber, Credit, Address
	FROM [dbo].[Client]
end
