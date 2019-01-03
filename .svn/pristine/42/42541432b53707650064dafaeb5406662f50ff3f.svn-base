USE ISAdb
GO
DELETE FROM ISAdb.dbo.RPPC
GO
INSERT INTO ISAdb.dbo.RPPC
(
	TPPCRecID, 
	RecordID, 
	JPPCRecID, 
	QtyAmbil, 
	NoACC, 
	[Status], 
	LAmbil, 
	QtySyarat, 
	RpSyarat, 
	QtyKirim, 
	HPPCRecID, 
	NamaToko, 
	WilID, 
	QtyACC
) 
SELECT
	RTRIM(idtppc),
	RTRIM(idrec),
	RTRIM(idjppc),
	q_ambil,
	RTRIM(noacc),
	[status],
	lambil,
	q_syarat,
	rp_syarat,
	q_kirim,
	RTRIM(idhppc),
	RTRIM(namatoko),
	RTRIM(idwil),
	q_acc
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM rppc')

GO
--SELECT * FROM RPPC 