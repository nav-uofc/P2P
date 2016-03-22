CREATE PROCEDURE common.sq_Select_One_User
    @UserId int
AS
BEGIN 
    SET NOCOUNT ON;

	SELECT
			[PASSWORD],
			[FIRST_NAME],
			[LAST_NAME],
			[MIDDLE_NAME],
			[BRIEF_BIO],
			[EMAIL],
			[USER_TYPE],
			[STAFF_ID],
			[STAFF_POSITION],
			[STUDENT_ID],
			[STUDENT_PROGRAM],
			[STUDENT_YEAR],
			[STUDENT_LEVEL],
			[INSTITUTION_ID],
			[DT_CREATED]
	FROM [common].[USERS]
	WHERE
			[PK_USER_ID] = @UserId
END
GO