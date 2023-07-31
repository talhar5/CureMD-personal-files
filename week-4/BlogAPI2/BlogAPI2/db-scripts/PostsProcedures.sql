USE [4879_BlogDb2];
GO


-- to get posts for a single user
DROP PROCEDURE IF EXISTS GetPostsByUser;
GO
CREATE PROCEDURE GetPostsByUser
	@UserId INT
AS
BEGIN
	SELECT *
	FROM Posts
	WHERE UserId = @UserId;
END
GO
-- to get posts by category
DROP PROCEDURE IF EXISTS GetPostsByCategory;
GO
CREATE PROCEDURE GetPostsByCategory
	@CategoryId INT
AS
BEGIN
	SELECT *
	FROM Posts
	WHERE CategoryId = @CategoryId;
END
GO
-- to get all posts and their author and category
DROP PROCEDURE IF EXISTS  GetAllPosts;
GO
CREATE PROCEDURE GetAllPosts
AS
BEGIN
	SELECT Posts.*, Users.FirstName, Users.LastName, Categories.CategoryName
	FROM Posts
	INNER JOIN Users ON Posts.UserId = Users.UserId
	INNER JOIN Categories ON Posts.CategoryId = Categories.CategoryId;
END
GO
DROP PROCEDURE IF EXISTS InsertPost;
GO
CREATE PROCEDURE InsertPost
	@Title VARCHAR(100),
	@PostBody TEXT,
	@CategoryId INT,
	@UserId INT
AS
BEGIN
	INSERT INTO Posts (Title, PostBody, UserId, CategoryId)
	VALUES (@Title, @PostBody, @CategoryId, @UserId);
END

GO

-- to delete a post by post id
DROP PROCEDURE IF EXISTS DeletePost
GO
CREATE PROCEDURE DeletePost
	@PostId INT
AS
BEGIN
	DELETE FROM Posts
	WHERE PostId = @PostId;
END
GO

-- to update a post by post id
DROP PROCEDURE IF EXISTS UpdatePost;
GO
CREATE PROCEDURE UpdatePost
	@PostId INT,
	@Title VARCHAR(100),
	@PostBody TEXT,
	@CategoryId INT
AS
BEGIN
	UPDATE Posts
	SET Title = @Title, PostBody = @PostBody, CategoryId = @CategoryId
	WHERE PostId = @PostId;
END
GO

