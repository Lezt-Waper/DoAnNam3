CREATE PROCEDURE [dbo].[spGood_GetAll]
AS
begin
	SELECT G.Id, G.Name, G.Quantity, C.Id AS CategoryId, C.CategoryName
	FROM [dbo].[Good] G
	INNER JOIN [dbo].[Category] C
		ON G.CategoryId = C.Id
end
