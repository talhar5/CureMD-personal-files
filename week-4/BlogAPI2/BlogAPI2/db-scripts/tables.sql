USE [master];
IF EXISTS (SELECT name FROM sys.databases WHERE name = '4879_BlogDb2')
DROP DATABASE [4879_BlogDb2];
GO
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = '4879_BlogDb2')
	BEGIN
		-- creating new database
		CREATE DATABASE [4879_BlogDb2];
		PRINT 'The database has been created';
	END
ELSE
	BEGIN
		PRINT 'The database already exists.';
	END
	
GO
USE [4879_BlogDb2];
GO
-- creating tables

-- Categories Table
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Categories')
	BEGIN
		CREATE TABLE Categories(
			CategoryId INT IDENTITY(1, 1) PRIMARY KEY,
			CategoryName VARCHAR(30) NOT NULL
		);
		PRINT 'A new Categories Table has been created';
	END

-- User Table

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Users')
	BEGIN
		CREATE TABLE Users (
			UserId INT IDENTITY(1, 1) PRIMARY KEY,
			FirstName VARCHAR(30) NOT NULL,
			LastName VARCHAR(30) NOT NULL,
			Email VARCHAR(50) NOT NULL UNIQUE,
			PasswordHash VARBINARY(MAX) NOT NULL,
			PasswordSalt VARBINARY(MAX) NOT NULL,
			JoinedOn DATETIME NOT NULL DEFAULT GETDATE()
		);
		PRINT 'A new User Table has been created';
	END
 -- Posts Table
 IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Posts')
	BEGIN
		CREATE TABLE Posts(
			PostId INT IDENTITY(1, 1) PRIMARY KEY,
			Title VARCHAR(100) NOT NULL,
			PostBody TEXT NOT NULL,
			UserId INT NOT NULL,
			FOREIGN KEY (UserId) REFERENCES Users(UserId),
			CategoryId INT NOT NULL,
			FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
		);
		PRINT 'A new Posts Table has been created';
	END

-- Comments Table
 IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Comments')
	BEGIN
		CREATE TABLE Comments(
			CommentId INT IDENTITY(1, 1) PRIMARY KEY,
			CommentBody VARCHAR(500) NOT NULL,
			UserId INT NOT NULL,
			FOREIGN KEY (UserId) REFERENCES Users(UserId),
			PostId INT NOT NULL,
			FOREIGN KEY (PostId) REFERENCES Posts(PostId)
		);
		PRINT 'A new Comments Table has been created';
	END
GO
