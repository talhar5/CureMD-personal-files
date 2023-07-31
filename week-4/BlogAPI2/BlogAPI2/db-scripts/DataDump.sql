use [4879_BlogDb2];
Go

-- Date Dump 
-- adding Categories
INSERT INTO Categories(CategoryName)
VALUES ('Food'),
		('Sports'),
		('Health'),
		('Travel'),
		('Cricket');

GO
-- inserting Users
INSERT INTO Users(FirstName, LastName, Email, PasswordHash, PasswordSalt)
VALUES ('Talha', 'Razzaq', 'talha@yahoo.com', CONVERT(VARBINARY, '0xEF1677FF76042304EE92A80AD4C45BC24410DC570A9EBF74B214CFD155631DA381DD07D6BF579161C238262B93A9ED5ED3BDD64FA92593BA9C193266D7B9B9D1'), CONVERT(VARBINARY, '0x744E96B69D0FE70C46E558F46D9A7C49FD2C7DBD01BB791D1AFFAE1212719CBA7B30770CCC88CBAB3DE5EA59B698F8F06C31F638F8C293A97DC0BEE9B56C2A91C6ABDA73631D94C069FD642B2B6B0FAB90698BF6A79C747AFC7E80D1A53E049543FABCFD03016198730018936FA84ED6C0FFCFD903C832E3F83E03B33B8929F6')),
('Hamza', 'Jameel', 'hamza@yahoo.com', CONVERT(VARBINARY, '0xEF1677FF76042304EE92A80AD4C45BC24410DC570A9EBF74B214CFD155631DA381DD07D6BF579161C238262B93A9ED5ED3BDD64FA92593BA9C193266D7B9B9D1'), CONVERT(VARBINARY, '0x744E96B69D0FE70C46E558F46D9A7C49FD2C7DBD01BB791D1AFFAE1212719CBA7B30770CCC88CBAB3DE5EA59B698F8F06C31F638F8C293A97DC0BEE9B56C2A91C6ABDA73631D94C069FD642B2B6B0FAB90698BF6A79C747AFC7E80D1A53E049543FABCFD03016198730018936FA84ED6C0FFCFD903C832E3F83E03B33B8929F6')),
('Aashar', 'Ch', 'aashar@yahoo.com', CONVERT(VARBINARY, '0xEF1677FF76042304EE92A80AD4C45BC24410DC570A9EBF74B214CFD155631DA381DD07D6BF579161C238262B93A9ED5ED3BDD64FA92593BA9C193266D7B9B9D1'), CONVERT(VARBINARY, '0x744E96B69D0FE70C46E558F46D9A7C49FD2C7DBD01BB791D1AFFAE1212719CBA7B30770CCC88CBAB3DE5EA59B698F8F06C31F638F8C293A97DC0BEE9B56C2A91C6ABDA73631D94C069FD642B2B6B0FAB90698BF6A79C747AFC7E80D1A53E049543FABCFD03016198730018936FA84ED6C0FFCFD903C832E3F83E03B33B8929F6')),
('Waqas', 'Arif', 'waqas@yahoo.com', CONVERT(VARBINARY, '0xEF1677FF76042304EE92A80AD4C45BC24410DC570A9EBF74B214CFD155631DA381DD07D6BF579161C238262B93A9ED5ED3BDD64FA92593BA9C193266D7B9B9D1'), CONVERT(VARBINARY, '0x744E96B69D0FE70C46E558F46D9A7C49FD2C7DBD01BB791D1AFFAE1212719CBA7B30770CCC88CBAB3DE5EA59B698F8F06C31F638F8C293A97DC0BEE9B56C2A91C6ABDA73631D94C069FD642B2B6B0FAB90698BF6A79C747AFC7E80D1A53E049543FABCFD03016198730018936FA84ED6C0FFCFD903C832E3F83E03B33B8929F6')),
('Emma', 'Johnson', 'emma@yahoo.com', CONVERT(VARBINARY, '0xEF1677FF76042304EE92A80AD4C45BC24410DC570A9EBF74B214CFD155631DA381DD07D6BF579161C238262B93A9ED5ED3BDD64FA92593BA9C193266D7B9B9D1'), CONVERT(VARBINARY, '0x744E96B69D0FE70C46E558F46D9A7C49FD2C7DBD01BB791D1AFFAE1212719CBA7B30770CCC88CBAB3DE5EA59B698F8F06C31F638F8C293A97DC0BEE9B56C2A91C6ABDA73631D94C069FD642B2B6B0FAB90698BF6A79C747AFC7E80D1A53E049543FABCFD03016198730018936FA84ED6C0FFCFD903C832E3F83E03B33B8929F6'));

GO

-- INSERTING POSTS
INSERT INTO Posts(Title, UserId, CategoryId, PostBody)
VALUES ('title of post', 1, 1, 'Mauris imperdiet quis neque quis pulvinar. Mauris posuere sit amet lacus vel tempor. Nunc lobortis sit amet leo nec pellentesque. Phasellus ut malesuada ipsum, vel lobortis nunc. Curabitur feugiat fringilla efficitur. Vestibulum porttitor et massa a semper. Fusce quis pulvinar lacus. Mauris porta odio ac enim pulvinar, ac venenatis odio elementum. Praesent porttitor urna eu eros pharetra, sed efficitur lacus egestas. Sed porta mattis tellus, a blandit nisl sodales nec. Sed ipsum est, accumsan vel elementum nec, blandit et odio. Nulla maximus ac nunc a scelerisque.'),
('title of post', 2, 2, 'Mauris imperdiet quis neque quis pulvinar. Mauris posuere sit amet lacus vel tempor. Nunc lobortis sit amet leo nec pellentesque. Phasellus ut malesuada ipsum, vel lobortis nunc. Curabitur feugiat fringilla efficitur. Vestibulum porttitor et massa a semper. Fusce quis pulvinar lacus. Mauris porta odio ac enim pulvinar, ac venenatis odio elementum. Praesent porttitor urna eu eros pharetra, sed efficitur lacus egestas. Sed porta mattis tellus, a blandit nisl sodales nec. Sed ipsum est, accumsan vel elementum nec, blandit et odio. Nulla maximus ac nunc a scelerisque.'),
('title of post', 3, 3, 'Mauris imperdiet quis neque quis pulvinar. Mauris posuere sit amet lacus vel tempor. Nunc lobortis sit amet leo nec pellentesque. Phasellus ut malesuada ipsum, vel lobortis nunc. Curabitur feugiat fringilla efficitur. Vestibulum porttitor et massa a semper. Fusce quis pulvinar lacus. Mauris porta odio ac enim pulvinar, ac venenatis odio elementum. Praesent porttitor urna eu eros pharetra, sed efficitur lacus egestas. Sed porta mattis tellus, a blandit nisl sodales nec. Sed ipsum est, accumsan vel elementum nec, blandit et odio. Nulla maximus ac nunc a scelerisque.'),
('title of post', 4, 4, 'Mauris imperdiet quis neque quis pulvinar. Mauris posuere sit amet lacus vel tempor. Nunc lobortis sit amet leo nec pellentesque. Phasellus ut malesuada ipsum, vel lobortis nunc. Curabitur feugiat fringilla efficitur. Vestibulum porttitor et massa a semper. Fusce quis pulvinar lacus. Mauris porta odio ac enim pulvinar, ac venenatis odio elementum. Praesent porttitor urna eu eros pharetra, sed efficitur lacus egestas. Sed porta mattis tellus, a blandit nisl sodales nec. Sed ipsum est, accumsan vel elementum nec, blandit et odio. Nulla maximus ac nunc a scelerisque.'),
('title of post', 5, 5, 'Mauris imperdiet quis neque quis pulvinar. Mauris posuere sit amet lacus vel tempor. Nunc lobortis sit amet leo nec pellentesque. Phasellus ut malesuada ipsum, vel lobortis nunc. Curabitur feugiat fringilla efficitur. Vestibulum porttitor et massa a semper. Fusce quis pulvinar lacus. Mauris porta odio ac enim pulvinar, ac venenatis odio elementum. Praesent porttitor urna eu eros pharetra, sed efficitur lacus egestas. Sed porta mattis tellus, a blandit nisl sodales nec. Sed ipsum est, accumsan vel elementum nec, blandit et odio. Nulla maximus ac nunc a scelerisque.');

GO

INSERT INTO Comments(UserId, PostId, CommentBody)
VALUES (5, 1, 'nice post dear'),
(4, 2, 'nice post dear'),
(3, 3, 'nice post dear'),
(2, 4, 'nice post dear'),
(1, 5, 'nice post dear');

GO

select *
from Posts;
select * 
from Categories
select *
from users
select *
from comments