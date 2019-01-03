USE ISAdb
GO
TRUNCATE TABLE DBO.DetailPlafon
GO
INSERT INTO dbo.DetailPlafon
	(	RowID,TransactionID,KodeToko,Tanggal,PlafonAwal,Bayar,
		Bgc,Bgt,Lembar,Hitung,PlafonAkhir,PlafonAjuan,Ajuan,PlafonACC,
		ACC,TglACC,Keterangan,PlafonHl,PlafonB,PlafonVt,PlafonOc,
		LastUpdatedBy,LastUpdatedTime)
SELECT 
	NEWID(),RTRIM(id_tr),kd_toko, Tanggal, p_awal,bayar,
	bgc,bgt,lembar,hitung,p_akhir,p_ajuan,ajuan,plafon_acc,
	acc,tgl_acc, ket, plf_hl, plf_b,plf_vt,plf_oc,
	'Importir', GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM dplafon')

GO 

UPDATE dbo.DetailPlafon 
	SET Tanggal = CASE WHEN YEAR(Tanggal)<=1900 THEN NULL ELSE Tanggal END,
		TglACC	= CASE WHEN YEAR(TglACC)<=1900 THEN NULL ELSE TglACC END
GO

DELETE FROM dbo.DetailPlafon 
WHERE LTRIM(RTRIM(KodeToko))=''
OR Tanggal IS NULL
OR RTRIM(LTRIM(TransactionID))='' 