/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
CREATE TRIGGER UpdateGoodQuantity
ON [dbo].[OrderDetail]
AFTER INSERT
AS
BEGIN
    DECLARE @GoodId NVARCHAR(20);
    DECLARE @Quantity INT;
    DECLARE @AvailableQuantity INT;

    SELECT @GoodId = i.GoodId, @Quantity = i.Quantity
    FROM inserted i

    SELECT @AvailableQuantity = G.Quantity
    FROM [dbo].[Good] G
    WHERE G.Id = @GoodId

    IF @Quantity > @AvailableQuantity
    BEGIN
        ROLLBACK TRANSACTION;
        RETURN;
    END

    UPDATE [dbo].[Good]
    SET Quantity = Quantity - @Quantity
    WHERE Id = @GoodId
END;
