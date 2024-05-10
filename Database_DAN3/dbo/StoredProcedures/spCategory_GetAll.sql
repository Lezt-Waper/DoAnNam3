CREATE PROCEDURE [dbo].[spCategory_GetAll]
AS
begin 
	SELECT Id AS CategoryId, CategoryName
	FROM dbo.[Category];
end 
