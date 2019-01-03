 USE ISAFinance 
GO
DELETE FROM dbo.KasirLog
GO
INSERT INTO dbo.KasirLog
(
	RowID, 
	Tanggal, 
	KasAwal,	KasMasuk, 	KasKeluar, 
	KasIndenAwal,	KasIndenMasuk,	KasIndenKeluar, 
	BGDAwal,	BGDMasuk,	BGDKeluar, 
	BGTAwal,	BGTMasuk, 	BGTKeluar,	
	BGIndenAwal, 	BGIndenMasuk, 	BGIndenKeluar, 
	BGTolakAwal, 	BGTolakMasuk, 	BGTolakKeluar, 
	BGInternalAwal, 	BGInternalMasuk, 	BGInternalKeluar, 
	BankAwal, 	BankMasuk, 	BankKeluar, 
	TrnIndenAwal, 	TrnIndenMasuk,	TrnIndenKeluar, 
	PKAwal,		PKMasuk, 	PKKeluar, 
	BSAwal,		BSMasuk, 	BSKeluar,
	CRDAwal,	CRDMasuk,	CRDKeluar,
	DBTAwal,	DBTMasuk,	DBTKeluar,
	LastUpdatedBy, 
	LastUpdatedTime,
	NPrint
)
SELECT 
	NEWID(),
	tanggal,
	kas_a,	kas_n,	kas_t,
	xkas_a,	xkas_n, xkas_t,
	bgd_a,	bgd_n,	bgd_t,
	bgt_a,	bgt_n,	bgt_t,
	xbgc_a,	xbgc_n,	xbgc_t,
	gt_a,	gt_n,	gt_t,
	bgb_a,	bgb_n,	bgb_t,
	bank_a,	bank_n,	bank_t,
	xtrf_a,	xtrf_n,	xtrf_t,
	piu_a,	piu_n,	piu_t,
	bon_a,	bon_n,	bon_t,
	xcrc_a,	xcrc_n,	xcrc_t,
	xdbc_a,	xdbc_n,	xdbc_t,
	'Import',
	getdate(),
	1
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM kasirlog')

GO



  