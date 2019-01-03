/*
Step 1:
	Ubah Field StokOpnm.TglOpnm ke Char(8)
Step 2 :
	Query Data Ke temporary Table
*/
-- last edited by Ferry

USE ISAdb
GO
DELETE FROM dbo.OpnameHistory 
GO


INSERT INTO dbo.OpnameHistory
(
	RowID,
	RecordID,
	TglOpname,
	QtyOpname,
	KodeBarang,
	KodeGudang,
	Keterangan,
	SyncFlag,
	LastUpdatedBy,
	LastUpdatedTime
)
SELECT 
	NEWID() AS RowID,
	RTRIM(idrec) AS RecordID,
	CAST((CASE WHEN tgl_opnm = '  /  /  ' THEN NULL
					   WHEN RIGHT(tgl_opnm,4) < 1900 THEN NULL
					  ELSE tgl_opnm 
					  END) AS DATETIME) AS TglOpname,
	ISNULL(qty_opnm,0)AS QtyAwal ,
	RTRIM(id_brg) AS KodeBarang,
	RTRIM(kd_gdg) AS KodeGudang,
	RTRIM(ket_opnm)AS Keterangan,
	id_match AS SyncFlag,
	'DELTA CRB',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT 
idrec,
DTOC(tgl_opnm) as tgl_opnm,
qty_opnm,
id_brg,
kd_gdg,
ket_opnm,
id_match
FROM StokOpnm')

GO

UPDATE DBO.OpnameHistory
SET RowID = b.RowID
FROM DBO.OpnameHistory a INNER JOIN ISAdb_JKT.DBO.OpnameHistory b ON a.RecordID = b.RecordID AND a.KodeGudang = b.KodeGudang

GO
--SELECT * FROM dbo.OpnameHistory
	 