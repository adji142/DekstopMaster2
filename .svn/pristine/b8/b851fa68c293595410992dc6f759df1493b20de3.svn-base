USE ISAdb 
GO
DELETE ISAdb.dbo.NotaPembelian
GO
SELECT 
  idtr,
  no_rq,
  tgl_rq,
  no_do,
  tgl_trans,
  no_nota,
  tgl_nota,
  no_sj,
  tgl_sj,
  tgl_trm,
  disc_1,
  disc_2,
  disc_3,
  id_disc,
  hr_krdt,
  ppn,
  pemasok,
  expedisi,
  cab,
  catatan,
  laudit,
  id_match
INTO #TEMP
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT 
  idtr,
  no_rq,
  tgl_rq,
  no_do,
  tgl_trans,
  no_nota,
  tgl_nota,
  no_sj,
  tgl_sj,
  DTOC(tgl_trm) as tgl_trm,
  disc_1,
  disc_2,
  disc_3,
  id_disc,
  hr_krdt,
  ppn,
  pemasok,
  expedisi,
  cab,
  catatan,
  laudit,
  id_match
  FROM htransb') 

INSERT INTO ISAdb.dbo.NotaPembelian
(
	RowID, 
	RecordID, 
	NoRequest, 
	TglRequest, 
	NoDO, 
	TglTransaksi, 
	NoNota, 
	TglNota, 
	NoSuratJalan, 
	TglSuratJalan, 
	TglTerima, 
	Disc1, 
	Disc2, 
	Disc3, 
	DiscFormula, 
	HariKredit, 
	PPN, 
	Pemasok, 
	Expedisi,
	Cabang,  
	Catatan,
	isClosed, 
	SyncFlag,  
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	RTRIM(idtr),
	RTRIM(no_rq),
	tgl_rq,
	RTRIM(no_do),
	tgl_trans,
	RTRIM(no_nota),
	tgl_nota,
	RTRIM(no_sj),
	tgl_sj,
	CAST((CASE WHEN tgl_trm = '  /  /  ' THEN NULL
					   WHEN LEFT(tgl_trm,2) =  '  ' THEN NULL
					   WHEN RIGHT(tgl_trm,4) < 1900 THEN NULL
					  ELSE RTRIM(tgl_trm) 
					  END) AS DATETIME) AS tgl_trm,
	disc_1,
	disc_2,
	disc_3,
	RTRIM(id_disc),
	hr_krdt,
	ppn,
	RTRIM(pemasok),
	RTRIM(expedisi),
	RTRIM(cab),
	catatan,
	laudit,
	id_match,	
	'Admin',
	GETDATE()
FROM #TEMP
	
DROP TABLE #TEMP

GO
--SELECT * FROM NotaPembelian 
