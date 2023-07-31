USE [4879_BlogDb2];
GO

-- CATEGORY PROCEDURE

-- to get all categories
DROP PROCEDURE IF EXISTS GetAllCategories;
GO
CREATE PROCEDURE GetAllCategories
AS
BEGIN 
	SELECT *
	FROM Categories;
END
GO

-- to insert a new category
DROP PROCEDURE IF EXISTS InsertCategory;
GO
CREATE PROCEDURE InsertCategory
	@CategoryName VARCHAR(30)
AS
BEGIN
	INSERT INTO Categories(CategoryName)
	VALUES (@CategoryName);
END
GO