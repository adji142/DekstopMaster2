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
	'Admin',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM hmutstok')
GO

--SELECT * FROM Mutasi