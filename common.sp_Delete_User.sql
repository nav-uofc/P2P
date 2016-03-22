CREATE PROCEDURE common.sp_Delete_User
    @UserId int 
AS
BEGIN 
    SET NOCOUNT ON;

	DELETE FROM [common].[USERS] WHERE PK_USER_ID = @UserId
END
GO