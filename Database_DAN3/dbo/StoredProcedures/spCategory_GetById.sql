CREATE PROCEDURE [dbo].[spCategory_Get]
	@Id int
AS
begin
	SELECT Id AS CategoryId, CategoryName
	FROM dbo.[Category]
	WHERE Id = @Id;
end
