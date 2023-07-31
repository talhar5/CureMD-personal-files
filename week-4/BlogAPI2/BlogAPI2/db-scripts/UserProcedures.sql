-- User Procedures
USE [4879_BlogDb2];
GO

-- to get all users
DROP PROCEDURE IF EXISTS GetAllUsers;
GO
CREATE PROCEDURE GetAllUsers
AS
BEGIN
	SELECT *
	FROM Users;
END
GO
-- To get a user by email
DROP PROCEDURE IF EXISTS GetUserByEmail;
Go
CREATE PROCEDURE GetUserByEmail
	@Email VARCHAR(50)
AS
BEGIN
	SELECT *
	FROM Users
	WHERE Email = @Email;
END
GO

-- To get a User by UserId
DROP PROCEDURE IF EXISTS GetUserById;
GO
CREATE PROCEDURE GetUserById
	@UserId INT
AS
BEGIN
	SELECT *
	FROM Users
	WHERE UserId = @UserId;
END
GO

-- To Insert a User
DROP PROCEDURE IF EXISTS InsertUser
GO
CREATE PROCEDURE InsertUser
	@FirstName VARCHAR(30),
	@LastName VARCHAR(30),
	@Email VARCHAR(50),
	@PasswordHash VARBINARY(MAX),
	@PasswordSalt VARBINARY(MAX),

	@PKID INT = 0 OUTPUT
AS
BEGIN
	INSERT INTO Users (FirstName, LastName, Email, PasswordHash, PasswordSalt)
	VALUES (@FirstName, @LastName, @Email, @PasswordHash, @PasswordSalt);

	SET @PKID = @@IDENTITY
	SELECT @PKID AS PKID;
END
GO

-- to check if the user exists or not
DROP PROCEDURE IF EXISTS CheckUserByEmail
GO
CREATE PROCEDURE CheckUserByEmail
	@Email VARCHAR(50),
	@IsRegistered BIT OUTPUT
AS
BEGIN
	IF EXISTS (SELECT 1 FROM Users WHERE email = @Email)
		SET @IsRegistered = 1;
	ELSE 
		SET @IsRegistered = 0;
END
GO

-- to update a user by user id
DROP PROCEDURE IF EXISTS UpdateUser;
GO
CREATE PROCEDURE UpdateUser
	@UserId INT,
	@FirstName VARCHAR(30),
	@LastName VARCHAR(30),
	@PasswordHash VARBINARY(MAX),
	@PasswordSalt VARBINARY(MAX)
AS
BEGIN
	UPDATE Users
	SET FirstName = @FirstName, LastName = @LastName, PasswordHash = @PasswordHash, PasswordSalt = @PasswordSalt
	WHERE UserId = @UserId;
END
GO
-- to update a user by user email
DROP PROCEDURE IF EXISTS UpdateUser;
GO
CREATE PROCEDURE UpdateUser
	@Email VARCHAR(50),
	@FirstName VARCHAR(30),
	@LastName VARCHAR(30),
	@PasswordHash VARBINARY(MAX),
	@PasswordSalt VARBINARY(MAX)
AS
BEGIN
	UPDATE Users
	SET FirstName = @FirstName, LastName = @LastName, PasswordHash = @PasswordHash, PasswordSalt = @PasswordSalt
	WHERE Email = @Email;
END
GO