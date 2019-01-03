 --Note:
--	1.	Convert tgl_retur di FOXPRO dari date ke Character(10)*	
--	2.	Convert tgl_kirim di FOXPRO dari date ke Character(10)*
--	
--  * untuk menghidari migrating error karena adanya empty date
-- last edited by ferry
USE ISAdb 
GO
--DELETE FROM ISAdb.dbo.ReturPembelian
DELETE FROM ISAdb.dbo.ReturPembelian
GO
INSERT INTO ISAdb.dbo.ReturPembelian
(
	RowID, 
	ReturID, 
	NoRetur, 
	TglRetur, 
	Pemasok, 
	Penerima, 
	TglKeluar, 
	Pengirim, 
	NoMPR, 
	TglKirim, 
	isClosed, 
	NPrint, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	RTRIM(idretur),
	RTRIM(no_retur),
	CAST((CASE WHEN tgl_retur = '  /  /  ' THEN NULL
					   WHEN RIGHT(tgl_retur,4) < 1900 THEN NULL
					  ELSE tgl_retur 
					  END) AS DATETIME) AS tgl_retur,
	--CONVERT(datetime, (CASE WHEN LEFT(tgl_retur, 2) = '' THEN NULL ELSE tgl_retur END)),
	RTRIM(pemasok),
	RTRIM(penerima),
	CAST((CASE WHEN tgl_keluar = '  /  /  ' THEN NULL
					   WHEN RIGHT(tgl_keluar,4) < 1900 THEN NULL
					  ELSE tgl_keluar 
					  END) AS DATETIME) AS tgl_keluar,
	
	--tgl_keluar,
	RTRIM(pengirim),
	RTRIM(no_mpr),
	CAST((CASE WHEN tgl_kirim = '  /  /  ' THEN NULL
					   WHEN RIGHT(tgl_kirim,4) < 1900 THEN NULL
					  ELSE tgl_kirim 
					  END) AS DATETIME) AS tgl_kirim,
	
	--CONVERT(datetime, (CASE WHEN LEFT(tgl_kirim, 2) = '' THEN NULL ELSE tgl_kirim END)),
	laudit,
	nprint,
	id_match,
	'DELTA CRB',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT
idretur,
no_retur,
DTOC(tgl_retur) as tgl_retur,
pemasok,
penerima,
DTOC(tgl_keluar)as tgl_keluar,
pengirim,
no_mpr,
DTOC(tgl_kirim) as tgl_kirim,
laudit,
nprint,
id_match
FROM hreturb')

GO

UPDATE DBO.ReturPembelian
SET RowID = b.RowID


FROM DBO.ReturPembelian a INNER JOIN ISAdb_JKT.DBO.ReturPembelian b ON a.ReturID = b.ReturID

GO 
--SELECT * FROM ReturPembelian 