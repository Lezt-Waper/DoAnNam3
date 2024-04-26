CREATE PROCEDURE [dbo].[spGood_GetByCategoryId]
	@CategoryId int
AS
begin
	SELECT G.Id, G.Name, G.Quantity, C.Id AS CategoryId, C.CategoryName
	FROM [dbo].[Good] G
	INNER JOIN [dbo].[Category] C
		ON G.CategoryId = C.Id
	WHERE G.CategoryId = @CategoryId
end
