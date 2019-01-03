USE ISAdb
GO
DELETE FROM ISAdb.dbo.DPJPPC
GO
INSERT INTO ISAdb.dbo.DPJPPC
(
	DODetailRecID, 
	DOHtrID, 
	HPCID, 
	PPCID, 
	RPPCRecID, 
	BarangID, 
	KodeToko, 
	QtyDO, 
	QtySJ
) 
SELECT
	RTRIM(iddpj),
	RTRIM(idhpj),
	RTRIM(idhpc),
	RTRIM(idppc),
	RTRIM(idrppc),
	RTRIM(id_brg),
	RTRIM(kd_toko),
	q_do,
	q_sj
	FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM dpjppc')


GO
--SELECT * FROM DPJPPC 