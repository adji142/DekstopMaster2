USE ISAdb
GO
DELETE FROM ISAdb.dbo.SecurityUsers
GO
INSERT INTO ISAdb.dbo.SecurityUsers
(
	UserID, 
	UserName, 
	Initial, 
	Password, 
	TglPassword, 
	Active, 
	LastUpdatedBy, 
	LastUpdatedTime
) 
SELECT
	RTRIM(Initial), 
	RTRIM(Nama), 
	RTRIM(Initial), 
	RTRIM(Password), 
	GETDATE(), 
	CASE WHEN Status = 'Active' THEN 1 ELSE 0 END, 
	'SYSTEM', 
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM [User]')

GO
SELECT  
*
--FROM dbo.SecurityUsers