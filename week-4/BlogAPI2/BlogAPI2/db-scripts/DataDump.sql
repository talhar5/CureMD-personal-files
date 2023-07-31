use [4879_BlogDb2];
Go

-- Date Dump 
EXEC InsertCategory @CategoryName = 'Football';
EXEC InsertCategory @CategoryName = 'Cricket';
EXEC InsertCategory @CategoryName = 'Gym';
EXEC InsertCategory @CategoryName = 'Dragon Ball';
EXEC InsertCategory @CategoryName = 'GOT';



select *
from Categories;