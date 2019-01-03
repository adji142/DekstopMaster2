USE ISAdb
GO
delete ISAdb.dbo.Opname
GO


INSERT INTO dbo.Opname
(
	RowID,
	RecordID,
	KodeBarang,
	TglStok,
	TglProses,
	TglTransfer,
	QtyAwal,
	Flag,
	Flag2,
	LinkID,
	SyncFlag,
	LastUpdatedBy,
	LastUpdatedTime
)
SELECT 
	NEWID(),
	RTRIM(idrec),
	RTRIM(id_brg),
	CONVERT(datetime , CASE LEFT(tglstok,2) WHEN '  ' THEN NULL ELSE RTRIM(tglstok) END ),
	CONVERT(datetime , CASE LEFT(tgl_proses,2) WHEN '  ' THEN NULL ELSE RTRIM(tgl_proses) END ),
	CONVERT(datetime , CASE LEFT(tgl_transf,2) WHEN '  ' THEN NULL ELSE RTRIM(tgl_transf) END ),
	q_awal,
	flag,
	flag2,
	id_link,
	id_match,
	'Admin',
	GETDATE()

FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM SasOpnm')
GO
UPDATE dbo.Opname
SET
TglProses=NULL
WHERE YEAR(tglProses)=1899
GO
UPDATE dbo.Opname
SET
TglTransfer=NULL
WHERE YEAR(TglTransfer)=1899
GO
--SELECT * FROM Opname