USE ISAdb 
GO
DELETE FROM ISAdb.dbo.MutasiDetail
GO
INSERT INTO ISAdb.dbo.MutasiDetail
(
	RowID, 
	HeaderID, 
	MutasiID, 
	RecordID,
	QtyMutasi,
	KodeBarang, 
	Keterangan,
	Gudang, 
	SyncFlag,
	LastUpdatedBy,
	LastUpdatedTime
)
SELECT 
	newID(), 
	NULL, 
	RTRIM(id_mts),
	RTRIM(idrec),
	j_mts,
	RTRIM(id_brg),
	RTRIM(catatan) ,
	RTRIM(kd_gdg),
	RTRIM(id_match),
	'DELTA CRB',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM dmutstok')

GO
UPDATE MutasiDetail 
set HeaderID= b.RowID 
FROM 
MutasiDetail a left outer join Mutasi b on a.MutasiId= b.MutasiID

GO

UPDATE DBO.MutasiDetail
SET RowID = b.RowID,
HeaderID = b.HeaderID
FROM DBO.MutasiDetail a INNER JOIN ISAdb_JKT.DBO.MutasiDetail b ON a.RecordID = b.RecordID

GO 
--SELECT * FROM MutasiDetail 
