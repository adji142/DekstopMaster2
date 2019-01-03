USE ISAdb
-- LAST EDITED BY FERRY
GO
--DELETE FROM ISAdb.dbo.Peminjaman
DELETE ISAdb.DBO.Peminjaman
GO

INSERT INTO dbo.Peminjaman
(
	RowID,
	NoBukti,
	RecordID,
	TglKeluar,
	TglBatas, 
	StaffPenjualan,
	Catatan,
	NPrint,
	SyncFlag,
	KodeSales,
	LastUpdatedBy,
	LastUpdatedTime
)

SELECT 
	NEWID(),
	RTRIM(noBukti),
	RTRIM(idtr),
	CAST((CASE WHEN tgl_kelpj = '  /  /  ' THEN NULL
					   WHEN RIGHT(tgl_kelpj,4) < 1900 THEN NULL
					  ELSE tgl_kelpj 
					  END) AS DATETIME) AS tgl_kelpj,
	--CONVERT(datetime , CASE LEFT(tgl_kelpj,2) WHEN '  ' THEN NULL ELSE RTRIM(tgl_kelpj) END ),
	--CONVERT(datetime , CASE LEFT(tgl_btspj,2) WHEN '  ' THEN NULL ELSE RTRIM(tgl_btspj) END ),
	CAST((CASE WHEN tgl_btspj = '  /  /  ' THEN NULL
					   WHEN RIGHT(tgl_btspj,4) < 1900 THEN NULL
					  ELSE tgl_btspj 
					  END) AS DATETIME) AS tgl_btspj,
	RTRIM(penjstaff),
	RTRIM(catatan),
	[print],
	RTRIM(id_match),
	RTRIM(kd_sales),
	'Admin',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT
 noBukti,
 idtr,
 DTOC(tgl_kelpj) AS tgl_kelpj,
 DTOC(tgl_btspj) AS tgl_btspj,
 penjstaff,
 catatan,
 print,
 id_match,
 kd_sales
 FROM Hpinjam')

GO
--SELECT * FROM   dbo.Peminjaman 