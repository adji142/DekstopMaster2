 USE ISAdb

GO
DELETE FROM ISAdb.dbo.Pengembalian

GO

INSERT INTO dbo.Pengembalian
(
	RowID,
	RecordID,
	NoBukti,
	TglKembaliPj,
	TglKembaliGdg,
	Catatan,
	NPrint,
	SyncFlag,
	KodeSales,
	LastUpdatedBy,
	LastUpdatedTime
)

SELECT 
	NEWID(),
	RTRIM(idtr),
	RTRIM(nobukti),
	tgl_kmbpj,
	tgl_kmbgd,
	RTRIM(catatan),
	[print],	
	 id_match,
	RTRIM(kd_sales),
	'Admin',
	GETDATE()

FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM HKembali')

GO
--SELECT * FROM   dbo.Pengembalian