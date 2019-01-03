USE ISAdb 
GO
DELETE FROM ISAdb.dbo.KasirLog
GO
INSERT INTO ISAdb.dbo.KasirLog
(
	RowID, 
	Tanggal, 
	KasAwal, KasNaik, KasTurun, 
	BankAwal, BankNaik, BankTurun, 
	BGDAwal, BGDNaik, BGDTurun, 
	BGTAwal, BGTNaik, BGTTurun, 
	BGBAwal, BGBNaik, BGBTurun, 
	GTAwal, GTNaik, GTTurun, 
	BonAwal, BonNaik, BonTurun, 
	PiutangAwal, PiutangNaik, PiutangTurun, 
	XKasAwal, XKasNaik, XKasTurun, 
	XTrfAwal, XTrfNaik, XTrfTurun, 
	XBGCAwal, XBGCNaik, XBGCTurun, 
	KorKasNaik, KorKasTurun, 
	KorBankNaik, KorBankTurun, 
	nPrint, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(), 
	tanggal, 
	kas_a, kas_n, kas_t, 
	bank_a, bank_n, bank_t, 
	bgd_a, bgd_n, bgd_t, 
	bgt_a, bgt_n, bgt_t, 
	bgb_a, bgb_n, bgb_t, 
	gt_a, gt_n, gt_t, 
	bon_a, bon_n, bon_t, 
	piu_a, piu_n, piu_t, 
	xkas_a, xkas_n, xkas_t, 
	xtrf_a, xtrf_n, xtrf_t, 
	xbgc_a, xbgc_n, xbgc_t, 
	korkas_n, korkas_t, 
	korbank_n, korbank_t,  
	(CASE WHEN prt_lhk IS NULL THEN 0 ELSE prt_lhk END), 
	(CASE WHEN id_match = '1' THEN 1 ELSE 0 END),
	'DELTA CRB', 
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM kasirlog')

--GO
--SELECT * FROM KasirLog 