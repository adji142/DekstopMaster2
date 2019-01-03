USE ISAdb
GO
DELETE FROM ISAdb.dbo.JPPC
GO
INSERT INTO ISAdb.dbo.JPPC
(
	HPPCRecID, 
	RecordID, 
	KodeBarang, 
	NamaBarang, 
	QtyHadiah, 
	QtyTotal, 
	QtyNota, 
	RpTotal, 
	RpNota, 
	Lunas, 
	SyncFlag
) 
SELECT
	RTRIM(idhppc),
	RTRIM(idrec),
	RTRIM(kd_brg),
	RTRIM(nm_brg),
	q_hadiah,
	q_total,
	q_nota,
	rp_total,
	rp_nota,
	lunas,
	id_match
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM jppc')

GO
--SELECT * FROM JPPC 