﻿CREATE PROCEDURE [dbo].[spGood_GetById]
	@Id int
AS
begin
	SELECT G.Id AS GoodId, G.Name, G.Price, G.Quantity, C.Id AS CategoryId, C.CategoryName
	FROM [dbo].[Good] G
	INNER JOIN [dbo].[Category] C
		ON G.CategoryId = C.Id
	WHERE G.Id = @Id
end
