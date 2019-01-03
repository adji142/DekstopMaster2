-- last edited by ferry, by adding composit key doc and sk
USE ISAdb 
GO
DELETE FROM ISAdb.dbo.Sopir
GO
INSERT INTO ISAdb.dbo.Sopir
(
	Nama, 
	Sk, 
	LastUpdatedBy, 
	LastUpdatedTime

	
)
SELECT 
	nama,
	sk,
	'DELTA CRB',
	getdate()

	
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM sopir')

UPDATE dbo.Sopir
SET	
	Sk = 'Sopir' 
WHERE 
	Sk = 'S' 

UPDATE dbo.Sopir
SET
	Sk = 'Kenek' 
WHERE 
	Sk = 'K' 
GO

--SELECT * FROM Sopir