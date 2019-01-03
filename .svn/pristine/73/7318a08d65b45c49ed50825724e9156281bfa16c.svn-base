USE ISAFinance 
GO
DELETE FROM dbo.ClosingGL
GO
INSERT INTO dbo.ClosingGL
(	
	RowID,
	Periode, 
	KodeGudang, 
	TglProses, 
	NoPerkiraan, 
	RpAkhir, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	RTRIM(Periode),	
	RTRIM(idcompany),
	tgl_Proses,
	RTRIM(kode),
	akhir,
	id_match,
	'Import',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_GL\'; ' '; ' ', 'SELECT * FROM Tutupbln')

GO
