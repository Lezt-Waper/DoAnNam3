CREATE PROCEDURE [dbo].[spCategory_Get]
	@Id NVARCHAR(15)
AS
begin
	SELECT Id AS CategoryId, CategoryName
	FROM dbo.[Category]
	WHERE Id = @Id;
end
