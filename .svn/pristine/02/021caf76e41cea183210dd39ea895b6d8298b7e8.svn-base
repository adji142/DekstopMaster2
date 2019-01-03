USE ISAdb 

GO
DELETE FROM ISAdb.dbo.WilTop

GO
INSERT INTO ISAdb.dbo.WilTop
(
	RowID, 
	TrID, 
	Wilayah, 
	LastUpdatedBy, 
	LastUpdatedTime
	
)
SELECT 
	NEWID(), 
	idtr,
	wilayah,
	'DELTA CRB',
	GETDATE()
	
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM Hwiltop')

GO
--SELECT * FROM WilTop
 