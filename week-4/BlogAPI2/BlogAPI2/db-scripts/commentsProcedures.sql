USE [4879_BlogDb2];
GO
 -- COMMENTS PROCEDRES

 -- To Get comments from a post
 DROP PROCEDURE IF EXISTS GetCommentsByPostId
 GO
 CREATE PROCEDURE GetCommentsByPostId
	@PostId INT
AS
BEGIN
	SELECT Comments.*, Users.FirstName, Users.LastName
	FROM Comments
	INNER JOIN Users ON Comments.UserId = Users.UserId
	WHERE PostId = @PostId;
END
GO

-- To insert a new comment on a post
 DROP PROCEDURE IF EXISTS InsertComment
 GO
 CREATE PROCEDURE InsertComment
	@PostId INT,
	@UserId INT,
	@CommentBody VARCHAR(500)
AS
BEGIN
	INSERT INTO Comments(CommentBody, UserId, PostId)
	VALUES (@CommentBody, @UserId, @PostId);
END
GO
 -- To delete a commment by commentId
 DROP PROCEDURE IF EXISTS DeleteComment;
 GO
 CREATE PROCEDURE DeleteComment
	@CommentId INT
AS
BEGIN
	DELETE FROM Comments
	WHERE CommentId = @CommentId;
END
GO