USE ISAdb 
GO
DELETE FROM ISAdb.dbo.OrderPenjualan 
GO

INSERT INTO ISAdb.dbo.OrderPenjualan
(
	RowID, 
	HtrID, 
	Cabang1, 
	Cabang2, 
	Cabang3, 
	NoRequest, 
	TglRequest, 
	NoDO, 
	TglDO, 
	NoACCPusat, 
	ACCPiutangID, 
	NoACCPiutang, 
	TglACCPiutang, 
	StatusBatal, 
	HariKredit, 
	KodeToko, 
	KodeSales, 
	AlamatKirim, 
	Kota, 
	DiscFormula, 
	Disc1, 
	Disc2, 
	Disc3,  
--	Plafon,
--	SaldoPiutang,
--	Overdue, 
--	QtyTolak, 
	isClosed, 
	Catatan1, 
	Catatan2, 
	Catatan3, 
	Catatan4, 
	Catatan5, 
	NoDOBO, 
	TglReorder, 
	StatusBO, 
	SyncFlag, 
	LinkID, 
	TransactionType, 
	Expedisi,
	Shift,
	HariKirim, 
	HariSales, 
	NPrint,
	LastUpdatedBy, 
	LastUpdatedTime,
	RpACCPiutang,
	RpPlafonToko,
	RpPiutangTerakhir,
	RpGiroTolakTerakhir,
	RpOverdue
)
SELECT 
	NEWID(), 
	RTRIM(idhtr), 
	RTRIM(cab1), 
	RTRIM(cab2), 
	RTRIM(cab3), 
	RTRIM(no_rq), 
	CAST((CASE WHEN tgl_rq = '  /  /  ' THEN NULL
			   WHEN RIGHT(tgl_rq,4) < 1900 THEN NULL
					ELSE tgl_rq 
			    END) AS DATETIME) AS tgl_rq, 
	RTRIM(no_do),
	CAST((CASE WHEN tgl_do = '  /  /  ' THEN NULL
			   WHEN RIGHT(tgl_do,4) < 1900 THEN NULL
					ELSE tgl_do 
			    END) AS DATETIME) AS tgl_do, 
	RTRIM(no_acc), 
	RTRIM(checker_1), 
	RTRIM(no_nota), 
	CAST((CASE WHEN tgl_nota = '  /  /  ' THEN NULL
			   WHEN RIGHT(tgl_nota,4) < 1900 THEN NULL
					ELSE tgl_nota 
			    END) AS DATETIME) AS tgl_nota, 
	RTRIM(no_sj), 
	hr_krdt, 
	RTRIM(kd_toko), 
	RTRIM(kd_sales), 
	RTRIM(al_kirim), 
	RTRIM(kota), 
	RTRIM(id_disc), 
	disc_1, 
	disc_2, 
	disc_3, 
--	pot_rp2, -- Plafon
--	pot_rp3, -- SaldoPiutang
--	CONVERT(money , CASE LEFT(RTRIM(rp_fee2),2) WHEN '  ' THEN '' ELSE RTRIM(rp_fee2) END ) as overdue, -- Overdue
--	CONVERT(int , CASE LEFT(RTRIM(rp_fee1),2) WHEN '  ' THEN '' WHEN '0.0' THEN FLOOR(rp_fee1) ELSE RTRIM(rp_fee1) END ) as qtytolak, -- QtyTolak
	laudit, 
	RTRIM(catatan1), 
	RTRIM(catatan2), 
	RTRIM(catatan3), 
	RTRIM(catatan4), 
	RTRIM(catatan5), 
	RTRIM(no_dobo), 
	CAST((CASE WHEN tgl_reord = '  /  /  ' THEN NULL
			   WHEN RIGHT(tgl_reord,4) < 1900 THEN NULL
					ELSE tgl_reord 
			    END) AS DATETIME) AS tgl_reord, 
	lbo, 
	id_match, 
	RTRIM(id_link), 
	RTRIM(id_tr), 
	RTRIM(expedisi),
	RTRIM(shift),
	hari_krm, 
	hari_sls, 
	nprint,
	'DELTA CRB', 
	GETDATE(),
	RP_net3,
	Pot_rp2    ,
	Pot_rp3    ,
	Rp_fee1    ,
	Rp_fee2    
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 
'SELECT 
 idhtr,
 cab1,
 cab2,
 cab3,
 no_rq,
 DTOC(tgl_rq) as tgl_rq,
 no_do,
 DTOC(tgl_do) as tgl_do,
 no_acc,
 checker_1,
 no_nota,
 DTOC(tgl_nota) as tgl_nota,
 no_sj,
 hr_krdt,
 kd_toko,
 kd_sales,
 al_kirim,
 kota,
 id_disc,
 disc_1,
 disc_2, 
 disc_3, 
 pot_rp2,
 pot_rp3,
 rp_fee1,
 STR(rp_fee2) as rp_fee2,
laudit, 
catatan1, 
catatan2, 
catatan3, 
catatan4, 
catatan5, 
no_dobo, 
DTOC(tgl_reord) as tgl_reord, 
lbo, 
id_match, 
id_link, 
id_tr, 
expedisi,
shift,
hari_krm, 
hari_sls, 
nprint,
RP_net3
 FROM hhtransj')

GO
UPDATE dbo.OrderPenjualan
SET [TglReorder] = NULL
WHERE TglReorder = '1899/12/30'

GO
UPDATE dbo.OrderPenjualan
SET [TglACCPiutang] = NULL
WHERE TglACCPiutang = '1899/12/30'

GO
UPDATE dbo.OrderPenjualan
SET [TglRequest] = NULL
WHERE TglRequest = '1899/12/30'

GO
UPDATE dbo.OrderPenjualan
SET [TglDO] = NULL
WHERE TglDO = '1899/12/30'

GO

UPDATE dbo.OrderPenjualan
SET [Shift] = '1'
WHERE [Shift] = ''

GO

CREATE TABLE ISAdb.dbo.OrderPenjualanTemp
(
	DORecID varchar(23),
	RecordID varchar (23),
	TransactionType varchar(2),
	HariSales int,
	HariKirim int,
	KodeSales varchar(11)
)
GO

CREATE CLUSTERED INDEX tempIndexDOJual ON OrderPenjualanTemp (DORecID, RecordID)
GO

INSERT INTO ISAdb.dbo.OrderPenjualanTemp
(
	DORecID,
	RecordID,
	TransactionType,	
	HariSales,
	HariKirim,
	KodeSales
)
SELECT
	RTRIM(idhtr),
	RTRIM(idtr),
	RTRIM(id_tr),
	hari_sls,
	hari_krm,
	kd_sales
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 
'SELECT a.idhtr,a.idtr,a.id_tr, a.hari_sls, a.hari_krm, a.kd_sales  FROM htransj a')
GO

UPDATE OrderPenjualan
SET 
	HariSales = tdo.HariSales,
	HariKirim = tdo.HariKirim,
	KodeSales = tdo.KodeSales
FROM OrderPenjualan hdo INNER JOIN OrderPenjualanTemp tdo ON hdo.HtrID = tdo.DORecID 


DROP TABLE OrderPenjualanTemp
GO

UPDATE DBO.OrderPenjualan
SET RowID = b.RowID

FROM DBO.OrderPenjualan a INNER JOIN ISAdb_JKT.DBO.OrderPenjualan b ON a.HtrID = b.HtrID



GO 