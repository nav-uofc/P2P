CREATE PROCEDURE common.sq_Update_User
    @UserId int, 
	@Password nvarchar(50), 
    @FirstName nvarchar(50),
	@LastName nvarchar(50), 
	@MiddleName nvarchar(50), 
	@BriefBio nvarchar(100), 
	@Email nvarchar(100), 
	@UserType char, 
	@StaffId nvarchar(20), 
	@StaffPosition nvarchar(20), 
	@StudentId nvarchar(20), 
	@StudentProgram nvarchar(50), 
	@StudentYear int, 
	@StudentLevel nvarchar(50), 
	@InstitutionId int
AS
BEGIN 
    SET NOCOUNT ON;

	UPDATE [common].[USERS]
	SET
			[PASSWORD] = @Password,
			[FIRST_NAME] = @FirstName,
			[LAST_NAME] = @LastName,
			[MIDDLE_NAME] = @MiddleName,
			[BRIEF_BIO] = @BriefBio,
			[EMAIL] = @Email,
			[USER_TYPE] = @UserType,
			[STAFF_ID] = @StaffId,
			[STAFF_POSITION] = @StaffPosition,
			[STUDENT_ID] = @StudentId,
			[STUDENT_PROGRAM] = @StudentProgram,
			[STUDENT_YEAR] = @StudentYear,
			[STUDENT_LEVEL] = @StudentLevel,
			[INSTITUTION_ID] = @InstitutionId
	WHERE
			[PK_USER_ID] = @UserId
END
GO