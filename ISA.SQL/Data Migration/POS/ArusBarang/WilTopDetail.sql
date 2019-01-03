USE ISAdb 

GO
DELETE FROM ISAdb.dbo.WilTopDetail

GO
INSERT INTO ISAdb.dbo.WilTopDetail
(
	RowID, 
	HeaderID,
	RecID,
	TrID, 
	Kota, 
	LastUpdatedBy, 
	LastUpdatedTime
	
)
SELECT 
	NEWID(), 
	b.RowID,
	a.idrec,
	a.idtr,
	a.kota,
	'DELTA CRB',
	GETDATE()
	
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM Dwiltop') a 
LEFT OUTER JOIN dbo.WilTop b
	ON a.idtr=b.TrID

GO
--SELECT * FROM WilTopDetail
 