 USE ISAdb 
GO
DELETE ISAdb.dbo.Mutasi
GO
INSERT INTO ISAdb.dbo.Mutasi
(
	RowID, 
	MutasiID, 
	TglMutasi, 
	NomorMutasi, 
	KeteranganMutasi,
	SyncFlag, 
	LAudit,
	TipeMutasi,
	LastUpdatedBy,	
	LastUpdatedTime
)
SELECT 
	newID(), 
	RTRIM(id_mts), 
	RTRIM(tgl_mts),
	RTRIM(no_mts),
	RTRIM(ket_mts) , 
	id_match,
	RTRIM(LAudit),
	RTRIM(type),
	'DELTA CRB',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM hmutstok')
GO

UPDATE DBO.Mutasi
SET RowID = b.RowID
FROM DBO.Mutasi a INNER JOIN ISAdb_JKT.DBO.Mutasi b ON a.MutasiID = b.MutasiID

GO 
--SELECT * FROM Mutasi