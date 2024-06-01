CREATE PROCEDURE [dbo].[spGood_GetByCategoryId]
	@CategoryId NVARCHAR(15)
AS
begin
	SELECT G.Id AS GoodId, G.Name, G.Price, G.Quantity, C.Id AS CategoryId, C.CategoryName
	FROM [dbo].[Good] G
	INNER JOIN [dbo].[Category] C
		ON G.CategoryId = C.Id
	WHERE G.CategoryId = @CategoryId
end
