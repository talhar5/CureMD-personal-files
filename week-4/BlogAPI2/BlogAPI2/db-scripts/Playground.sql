
--To check the acitve connections
USE master;
SELECT request_session_id
FROM sys.dm_tran_locks
WHERE resource_database_id = DB_ID('4879_BlogDb2');
kill 60;

