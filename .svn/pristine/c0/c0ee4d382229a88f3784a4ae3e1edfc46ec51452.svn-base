  USE ISAdb 
GO
DELETE FROM ISAdb.dbo.BuktiDetail
GO
INSERT INTO ISAdb.dbo.BuktiDetail
(
	RowID, 
	HeaderID, 
	RecordID, 
	HeaderRecID, 
	BonSementaraID, 
	Kode, 
	Sub, 
	NoPerkiraan, 
	Uraian, 
	Jumlah, 
	NoChBG, 
	Bank, 
	TglJatuhTempo, 
	SyncFlag, 
	LastUpdatedBy,
	LastUpdatedTime
)
SELECT 
	NEWID(), 
	h.RowID, 
	RTRIM(d.idrec), 
	ISNULL(h.RecordID, ''), 
	RTRIM(d.idbs), 
	RTRIM(d.kode), 
	RTRIM(d.sub), 
	RTRIM(d.no_perk), 
	RTRIM(d.uraian), 
	d.jumlah, 
	RTRIM(d.ch_gb_no), 
	RTRIM(d.bank), 
	d.tgl_jt, 
	(CASE WHEN d.id_match = '1' THEN 1 ELSE 0 END), 
	'DELTA CRB',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM dbukti') d
LEFT OUTER JOIN dbo.Bukti h ON RTRIM(d.idtr) = h.RecordID
 
--GO
--SELECT * FROM BuktiDetail