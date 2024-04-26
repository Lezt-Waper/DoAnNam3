CREATE PROCEDURE [dbo].[spCategory_GetAll]
AS
begin 
	SELECT Id, CategoryName
	FROM dbo.[Category];
end 
