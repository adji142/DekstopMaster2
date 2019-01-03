--Note:
--	1.	Convert tgl_trm di FOXPRO dari date ke character(10) 	
--		(untuk menghidari migrating error karena adanya empty date)
--	2.	Convert j_retur di FOXPRO dari date ke character(10)
--		(ada data korup di field j_retur)

USE ISAdb 
GO
DELETE ISAdb.dbo.NotaPembelianDetail
GO

SELECT b.RowID,
	RTRIM(a.idrec) AS idrec,
	RTRIM(a.idtr) as idtr,
	RTRIM(a.id_brg) as id_brg,
	a.j_rq,
	a.j_do,
	a.j_sj,
	a.j_nota,
    --CONVERT(int, (CASE WHEN a.j_retur = '*****' THEN '0' ELSE a.j_retur END)),
	RTRIM(a.catatan)as catatan,
	CAST((CASE WHEN tgl_trm = '  /  /  ' THEN NULL
					   WHEN RIGHT(tgl_trm,4) < 1900 THEN NULL
					  ELSE RTRIM(tgl_trm) 
					  END) AS DATETIME) AS tgl_trm,
	a.h_beli,
	a.h_pokok,
	a.hpp_solo,
	a.pot_rp,
	a.disc_1,
	a.disc_2,
	a.disc_3,
	RTRIM(a.id_disc) as id_disc,
	a.ppn,
	RTRIM(a.kd_gdg) as kd_gdg,
	RTRIM(a.id_koreksi) as id_koreksi,
	a.id_match
INTO #TEMP
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT 
 idrec,
 idtr,
 id_brg,
 j_rq,
 J_do,
 j_sj,
 j_nota,
 DTOC(tgl_trm) as tgl_trm,
 catatan,
 h_beli,
 h_pokok,
 hpp_solo,
 pot_rp,
 disc_1,
 disc_2,
 disc_3,
 id_disc,
 ppn,
 kd_gdg,
 id_koreksi,
 id_match
 FROM dtransb') a
LEFT OUTER JOIN dbo.NotaPembelian b ON RTRIM(a.idtr) = b.RecordID


INSERT INTO ISAdb.dbo.NotaPembelianDetail
(
	RowID, 
	HeaderID, 
	RecordID, 
	HeaderRecID, 
	BarangID, 
	QtyRequest, 
	QtyDO, 
	QtySuratJalan, 
	QtyNota, 
	--QtyRetur, 
	Catatan, 
	TglTerima,
	HrgBeli, 
	HrgPokok, 
	HPPSolo, 
	Pot, 
	Disc1, 
	Disc2, 
	Disc3, 
	DiscFormula, 
	PPN, 
	KodeGudang, 
	KoreksiID, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	RowID,
	idrec,
	idtr,
	id_brg,
	j_rq,
	j_do,
	j_sj,
	j_nota,
    --CONVERT(int, (CASE WHEN a.j_retur = '*****' THEN '0' ELSE a.j_retur END)),
	catatan,
	tgl_trm,
	--CONVERT(datetime , CASE LEFT(a.tgl_trm,2) WHEN '  ' THEN NULL ELSE RTRIM(a.tgl_trm) END ),
	h_beli,
	h_pokok,
	hpp_solo,
	pot_rp,
	disc_1,
	disc_2,
	disc_3,
	id_disc,
	ppn,
	kd_gdg,
	id_koreksi,
	id_match,
	'Admin',
	GETDATE()  
 FROM #TEMP

DROP TABLE #TEMP

GO
--SELECT * FROM NotaPembelianDetail
