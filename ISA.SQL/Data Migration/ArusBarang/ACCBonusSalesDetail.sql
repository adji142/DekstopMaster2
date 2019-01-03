USE ISAdb 
GO
DELETE FROM ISAdb.dbo.ACCBonusSalesDetail
GO
INSERT INTO ISAdb.dbo.ACCBonusSalesDetail 
(
	RowID, 
	HeaderID, 
	NotaDetailID, 
	NotaRecID, 
	NotaDetailRecID, 
	BarangID, 
	QtySuratJalan, 
	HrgNetto, 
	NoACC, 
	TglACC, 
	KodeSales, 
	KodeGudang, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(), 
	b.RowID, 
	NULL,
	RTRIM(a.idtr), 
	RTRIM(a.idrec), 
	RTRIM(a.id_brg), 
	a.j_sj, 
	a.h_netto,
	a.no_acc, 
	a.tgl_acc,
	RTRIM(a.kd_sales),
	RTRIM(a.c1),
	'Admin', 
	GETDATE()

FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM daccbns') a
LEFT OUTER JOIN dbo.ACCBonusSales b ON RTRIM(a.idtr) = b.NotaRecID 


UPDATE DBO.ACCBonusSalesDetail
SET NotaDetailID = c.RowID
FROM DBO.ACCBonusSalesDetail a 
LEFT OUTER JOIN DBO.ACCBonusSales b ON a.HeaderID = b.RowID
LEFT OUTER JOIN DBO.NotaPenjualanDetail c ON a.NotaRecID = c.RecordID
WHERE b.Keterangan = 'J'



UPDATE DBO.ACCBonusSalesDetail
SET NotaDetailID = c.RowID
FROM DBO.ACCBonusSalesDetail a 
LEFT OUTER JOIN DBO.ACCBonusSales b ON a.HeaderID = b.RowID
LEFT OUTER JOIN DBO.ReturPenjualanDetail c ON a.NotaRecID = c.RecordID
WHERE b.Keterangan <> 'J'





GO
UPDATE dbo.ACCBonusSalesDetail
SET TglACC = NULL
WHERE TglACC = '1899/12/30'

GO
