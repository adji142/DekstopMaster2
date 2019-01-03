USE ISAFinance 
GO
DELETE FROM dbo.TransaksiBank 
GO
INSERT INTO dbo.TransaksiBank
(
	KodeTransaksi, 
	NamaTransaksi, 
	DK, 
	BGCH, 
	Keterangan, 
	Kode, 
	Sub, 
	NoPerkiraan, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	RTRIM(kd_trs),
	RTRIM(nm_trs),
	RTRIM(dbcr),
	RTRIM(bgch),
	RTRIM(ke_ket),
	RTRIM(Kode),
	RTRIM(sub),
	RTRIM(no_perk),
	'DELTA CRB',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM trsbank')

GO

 