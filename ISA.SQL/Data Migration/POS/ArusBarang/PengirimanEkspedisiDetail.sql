 USE ISAdb 
GO
DELETE FROM ISAdb.dbo.PengirimanEkspedisiDetail
GO
INSERT INTO ISAdb.dbo.PengirimanEkspedisiDetail
(
	RowID, 
	HeaderID, 
	TrID, 
	RecordID, 
	RekapKoliID, 
	KetPending, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	newid(), 
	b.RowID, 
	a.idtr, 
	a.idrec, 
	d.RowID, 
	a.ket_pend, 
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM Dxpdckp') a 
LEFT OUTER JOIN dbo.PengirimanEkspedisi b ON a.idtr = b.TrID
LEFT OUTER JOIN dbo.RekapKoli d ON d.RecordID = a.idxpdc

GO

UPDATE DBO.PengirimanEkspedisiDetail
SET RowID = b.RowID,
HeaderID = b.HeaderID,
RekapKoliID = b.RekapKoliID

FROM DBO.PengirimanEkspedisiDetail a INNER JOIN ISAdb_JKT.DBO.PengirimanEkspedisiDetail b ON a.RecordID = b.RecordID



GO 
--SELECT * FROM PengirimanEkspedisiDetail 