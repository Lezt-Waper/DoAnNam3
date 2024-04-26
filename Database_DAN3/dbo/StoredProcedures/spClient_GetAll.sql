CREATE PROCEDURE [dbo].[spClient_GetAll]
AS
begin
	SELECT Name, PhoneNumber, Credit, Address
	FROM [dbo].[Client]
end
