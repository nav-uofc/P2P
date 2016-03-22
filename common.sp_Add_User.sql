CREATE PROCEDURE common.sq_Add_User
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

	insert into [common].[USERS]
		(
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
		)
	values
		(
			@Password,
			@FirstName,
			@LastName,
			@MiddleName,
			@BriefBio,
			@Email,
			@UserType,
			@StaffId,
			@StaffPosition,
			@StudentId,
			@StudentProgram,
			@StudentYear,
			@StudentLevel,
			@InstitutionId,
			getdate()
		)
END
GO